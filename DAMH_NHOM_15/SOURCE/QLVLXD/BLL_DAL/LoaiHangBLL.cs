using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class LoaiHangBLL
    {
        VLXDDataContext vlxd = new VLXDDataContext();
        
        public DataTable getAllByCode(string code)
        {
            DataTable dt = new DataTable();
            var kq = from tcs in vlxd.LoaiHangs
                     where tcs.MaLoai == code
                     select tcs;
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
            var kq = from tcs in vlxd.LoaiHangs select tcs;

            if (!kq.Any()) return null;

            var dt = new DataTable();
            foreach (var prop in typeof(LoaiHang).GetProperties())
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
            return dt;
        }


        public LoaiHang getByCode(string code)
        {
            return vlxd.LoaiHangs.Where(t => t.MaLoai == code).FirstOrDefault();
        }

        public string GetNextMaLoaiHang()
        {
            // Lấy giá trị MaLoaiHang lớn nhất hiện tại trong danh sách nhà cung cấp
            var maxMaLoaiHang = vlxd.LoaiHangs
                .OrderByDescending(t => t.MaLoai)
                .FirstOrDefault()?.MaLoai;

            if (maxMaLoaiHang == null)
            {
                // Nếu không có mã loại hàng nào, trả về mã mặc định
                return "LH001";
            }

            //Dạng Mã Loại Hàng là 'LH001'
            string prefix = new string(maxMaLoaiHang.TakeWhile(char.IsLetter).ToArray());
            string numberPart = maxMaLoaiHang.Substring(prefix.Length);

            if (int.TryParse(numberPart, out int number))
            {
                // Tăng giá trị số và tạo mã mới
                number++;
                return $"{prefix}{number:D3}"; // D3 định dạng số có 3 chữ số
            }

            throw new InvalidOperationException("Invalid MaLoaiHang format.");
        }

        public List<string> getTinhTrangList()
        {
            return vlxd.LoaiHangs
                .Select(lh => lh.TinhTrang)
                .Distinct() // Đảm bảo không trùng lặp giá trị
                .ToList();
        }
        public bool addItemLoaiHang(LoaiHang a)
        {
            bool b = false;
            if (a != null)
            {
                try
                {
                    vlxd.LoaiHangs.InsertOnSubmit(a);
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

        public bool updateItemLoaiHang(LoaiHang a, LoaiHang d)
        {
            try
            {
                // Câu truy vấn SQL để cập nhật thông tin nhà cung cấp
                string query = string.Format("UPDATE LoaiHang SET TenLoai = '{1}', TinhTrang = '{2}' WHERE MaLoai = '{0}'",
                                            a.MaLoai,
                                            d.TenLoai != null && d.TenLoai != "" ? d.TenLoai : a.TenLoai,
                                            d.TinhTrang != null && d.TinhTrang != "" ? d.TinhTrang : a.TinhTrang);

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



        public bool deleteItemLoaiHang(LoaiHang a)
        {
            bool b = false;
            if (a != null)
            {
                try
                {
                    vlxd.LoaiHangs.DeleteOnSubmit(a);
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
