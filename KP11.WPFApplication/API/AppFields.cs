using KP11.Integration;
using KP11.WPFApplication.MVVM.Model;

namespace KP11.WPFApplication;

public static class AppFields
{
    public static MainWindow MainWindow { get; set; }

    public static KP11Client Client { get; set; }

    public static ProfessorModel LastSelectedProfessor { get; set; }
}