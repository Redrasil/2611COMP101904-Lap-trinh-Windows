namespace COMP1019_Lab12_GradeManager;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Forms.FrmNhapDiemTheoLop());
    }
}
