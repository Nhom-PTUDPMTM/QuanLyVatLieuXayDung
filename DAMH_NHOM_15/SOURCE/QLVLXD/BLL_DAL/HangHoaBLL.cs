using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class HangHoaBLL
    {
        VLXDDataContext vlxd = new VLXDDataContext();

        public DataTable getAllByCode(string code)
        {
            DataTable dt = new DataTable();
            var kq = from hh in vlxd.HangHoas
                     where hh.MaLoai == code
                     select hh;
            if (kq.Any())
            {
                var firstItem = kq.First();
                foreach (var prop in firstItem.GetType().GetProperties())
                {
                    dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                foreach (var item in kq)
                {
                    var row = dt.NewRow();
                    foreach (var prop in item.GetType().GetProperties())
                    {
                        row[prop.Name] = prop.GetValue(item, null) ?? DBNull.Value;
                    }
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }

        public DataTable getAll()
        {
            var kq = from hh in vlxd.HangHoas
                     join lh in vlxd.LoaiHangs on hh.MaLoai equals lh.MaLoai
                     select new
                     {
                         hh.MaHH,
                         hh.TenHH,
                         hh.MaLoai,
                         hh.DonVi,
                         hh.DonGia,
                         hh.SoLuongTon,
                         TenLoai = lh.TenLoai
                     };

            if (!kq.Any()) return null;

            var dt = new DataTable();
            // Tạo cột cho DataTable dựa trên các thuộc tính của kết quả phép join
            foreach (var prop in kq.First().GetType().GetProperties())
            {
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            // Thêm các hàng vào DataTable
            foreach (var item in kq)
            {
                var row = dt.NewRow();
                foreach (var prop in item.GetType().GetProperties())
                {
                    row[prop.Name] = prop.GetValue(item, null) ?? DBNull.Value;
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        public HangHoa getByCode(string code)
        {
            return vlxd.HangHoas.Where(t => t.MaHH == code).FirstOrDefault();
        }

        public string GetNextMaHangHoa()
        {
            // Lấy giá trị MaHH lớn nhất hiện tại trong danh sách nhà cung cấp
            var maxMaHH = vlxd.HangHoas
                .OrderByDescending(t => t.MaHH)
                .FirstOrDefault()?.MaHH;

            if (maxMaHH == null)
            {
                // Nếu không có mã hh nào, trả về mã mặc định
                return "HH001";
            }

            //Dạng Mã Loại Hàng là 'HH001'
            string prefix = new string(maxMaHH.TakeWhile(char.IsLetter).ToArray());
            string numberPart = maxMaHH.Substring(prefix.Length);

            if (int.TryParse(numberPart, out int number))
            {
                // Tăng giá trị số và tạo mã mới
                number++;
                return $"{prefix}{number:D3}"; // D3 định dạng số có 3 chữ số
            }

            throw new InvalidOperationException("Invalid MaHH format.");
        }

        public List<string> getMaLoaiList()
        {
            return vlxd.LoaiHangs
                .Select(lh => lh.MaLoai)
                .Distinct() // Đảm bảo không trùng lặp giá trị
                .ToList();
        }
        public bool addItemHangHoa(HangHoa a)
        {
            bool b = false;
            if (a != null)
            {
                try
                {
                    vlxd.HangHoas.InsertOnSubmit(a);
                    vlxd.SubmitChanges();
                    b = true;
                }
                catch
                {
                    b = false;
                }
            }
            return b;
        }

        public bool updateItemHangHoa(HangHoa a, HangHoa d)
        {
            try
            {
                // Câu truy vấn SQL để cập nhật thông tin nhà cung cấp
                string query = string.Format("UPDATE HangHoa SET TenHH = '{1}', MaLoai = '{2}', DonVi = '{3}'" +
                                            " , DonGia = '{4}', SoLuongTon = '{5}' " +
                                            " WHERE MaHH = '{0}'",
                                            a.MaHH,
                                            d.TenHH != null && d.TenHH != "" ? d.TenHH : a.TenHH,
                                            d.MaLoai != null && d.MaLoai != "" ? d.MaLoai : a.MaLoai,
                                            d.DonVi != null && d.DonVi != "" ? d.DonVi : a.DonVi,
                                            d.DonGia != null && d.DonGia != 0 ? d.DonGia : a.DonGia,
                                            d.SoLuongTon != null && d.SoLuongTon != 0 ? d.SoLuongTon : a.SoLuongTon);

                // Thực thi câu truy vấn
                int result = DataProvider.Instance.executeNonQuery(query);

                // Trả về true nếu có ít nhất 1 dòng bị ảnh hưởng
                return result > 0;
            }
            catch (Exception ex)
            {
                // Ghi lại thông tin lỗi để kiểm tra
                Console.WriteLine(ex.Message);
                return false;
            }
        }



        public bool deleteItemHanghoa(HangHoa a)
        {
            bool b = false;
            if (a != null)
            {
                try
                {
                    vlxd.HangHoas.DeleteOnSubmit(a);
                    vlxd.SubmitChanges();
                    b = true;
                }
                catch
                {
                    b = false;
                }
            }
            return b;
        }
    }
}
