 
namespace OnlineSchool_Project.Models.User
{
	public class KhoaHocViewModel
	{
		public KhoaHoc KhoaHocs { get; set; } = new KhoaHoc();
		public ChuongHoc ChuongHocs { get; set; } = new ChuongHoc();
		public BaiHoc BaiHocs { get; set; } = new BaiHoc();
	}
}