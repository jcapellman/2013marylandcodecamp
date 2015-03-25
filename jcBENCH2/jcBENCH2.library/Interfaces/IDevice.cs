namespace jcBENCH2.library.Interfaces {
    public interface IDevice {
        string Manufacturer { get; }
        string CPUName { get; }
        int CPUCount { get; }
        string CPUArchitecture { get; }
    }
}
