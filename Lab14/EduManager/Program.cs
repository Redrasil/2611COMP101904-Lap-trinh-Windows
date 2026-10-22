using EduManager.BLL;
using EduManager.DAL;
using EduManager.Data;
using EduManager.GUI;

namespace EduManager;
internal static class Program
{
    [STAThread] private static void Main()
    {
        ApplicationConfiguration.Initialize();
        using var context = new EduManagerContext();
        Application.Run(new FrmMonHoc(new MonHocBLL(new MonHocDAL(context))));
    }
}
