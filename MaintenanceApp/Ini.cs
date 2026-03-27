using System;
using System.Runtime.InteropServices;
using System.Text;

public class IniFile
{
    private string filePath;

    public IniFile(string path)
    {
        filePath = path;
    }

    // Đọc giá trị
    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    private static extern int GetPrivateProfileString(
        string section,
        string key,
        string defaultValue,
        StringBuilder returnValue,
        int size,
        string filePath);

    // Ghi giá trị
    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    private static extern long WritePrivateProfileString(
        string section,
        string key,
        string value,
        string filePath);

    public string Read(string section, string key, string defaultValue = "")
    {
        StringBuilder temp = new StringBuilder(255);
        GetPrivateProfileString(section, key, defaultValue, temp, 255, filePath);
        return temp.ToString();
    }

    public void Write(string section, string key, string value)
    {
        WritePrivateProfileString(section, key, value, filePath);
    }

    public void DeleteKey(string section, string key)
    {
        WritePrivateProfileString(section, key, null, filePath);
    }

    public void DeleteSection(string section)
    {
        WritePrivateProfileString(section, null, null, filePath);
    }

    public bool KeyExists(string section, string key)
    {
        return Read(section, key).Length > 0;
    }
}