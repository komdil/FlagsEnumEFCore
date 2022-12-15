namespace FlagsEnumEFCore
{
    [Flags]
    internal enum Role
    {
        Simple = 1,
        Customer = 2,
        Employee = 4,
        Manager = 8,
        Director = 16,
        Admin = 32
    }
}
