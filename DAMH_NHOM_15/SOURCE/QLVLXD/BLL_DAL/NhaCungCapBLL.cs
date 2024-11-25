using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics.Tensors;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL_DAL
{
    public class NhaCungCapBLL
    {
        VLXDDataContext vlxd = new VLXDDataContext();

        public DataTable getCodeAndName()
        {
            DataTable dt = new DataTable();
            var kq = from tcs in vlxd.NhaCCs
                     select new
                     {
                         MaNCC = tcs.MaNCC,
                         TenNCC = tcs.TenNCC
                     };
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

        public DataTable getAllByCode(string code)
        {
            DataTable dt = new DataTable();
            var kq = from tcs in vlxd.NhaCCs
                     where tcs.MaNCC == code
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
            var kq = from tcs in vlxd.NhaCCs select tcs;

            if (!kq.Any()) return null;

            var dt = new DataTable();
            foreach (var prop in typeof(NhaCC).GetProperties())
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


        public NhaCC getByCode(string code)
        {
            return vlxd.NhaCCs.Where(t => t.MaNCC == code).FirstOrDefault();
        }

        public string GetNextMaNCC()
        {
            // Lấy giá trị MaNCC lớn nhất hiện tại trong danh sách nhà cung cấp
            var maxMaNCC = vlxd.NhaCCs
                .OrderByDescending(t => t.MaNCC)
                .FirstOrDefault()?.MaNCC;

            if (maxMaNCC == null)
            {
                // Nếu không có mã nhà cung cấp nào, trả về mã mặc định
                return "NCC001";
            }

            //Dạng Mã Nhà Cung Cấp là 'NCC001'
            string prefix = new string(maxMaNCC.TakeWhile(char.IsLetter).ToArray());
            string numberPart = maxMaNCC.Substring(prefix.Length);

            if (int.TryParse(numberPart, out int number))
            {
                // Tăng giá trị số và tạo mã mới
                number++;
                return $"{prefix}{number:D3}"; // D3 định dạng số có 3 chữ số
            }

            throw new InvalidOperationException("Invalid MaNCC format.");
        }


        public bool addItemNCC(NhaCC a)
        {
            bool b = false;
            if (a != null)
            {
                try
                {
                    vlxd.NhaCCs.InsertOnSubmit(a);
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

        public bool updateItemNCC(NhaCC a, NhaCC d)
        {
            try
            {
                // Câu truy vấn SQL để cập nhật thông tin nhà cung cấp
                string query = string.Format("UPDATE NhaCC SET TenNCC = '{1}', DiaChi = '{2}', SDT = '{3}' WHERE MaNCC = '{0}'",
                                            a.MaNCC,
                                            d.TenNCC != null && d.TenNCC != "" ? d.TenNCC : a.TenNCC, // Kiểm tra nếu d.TenNCC có giá trị thì cập nhật, nếu không dùng a.TenNCC
                                            d.DiaChi != null && d.DiaChi != "" ? d.DiaChi : a.DiaChi, // Tương tự cho DiaChi
                                            d.SDT != null && d.SDT != "" ? d.SDT : a.SDT); // Tương tự cho SDT

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



        public bool deleteItemNCC(NhaCC a)
        {
            bool b = false;
            if (a != null)
            {
                try
                {
                    vlxd.NhaCCs.DeleteOnSubmit(a);
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
