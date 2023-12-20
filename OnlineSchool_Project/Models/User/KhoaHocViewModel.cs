 
namespace OnlineSchool_Project.Models.User
{
	public class KhoaHocViewModel
	{
		public KhoaHoc KhoaHocs { get; set; } = new KhoaHoc();
		public List<ChuongHoc> ChuongHocs { get; set; } = new List<ChuongHoc>();
		public List<BaiHoc> BaiHocs { get; set; } = new List<BaiHoc>();
	}
}