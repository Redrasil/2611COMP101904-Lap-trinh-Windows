using StudentMvpDemo.Repositories;
using StudentMvpDemo.Presenters;
using StudentMvpDemo.Views;

namespace StudentMvpDemo;
internal static class Program
{
    [STAThread] private static void Main() { ApplicationConfiguration.Initialize(); var view = new FrmStudent(); _ = new StudentPresenter(view, new StudentRepository()); Application.Run(view); }
}
