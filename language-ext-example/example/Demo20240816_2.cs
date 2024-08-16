namespace language_ext_example.example;

using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using LanguageExt;
using LanguageExt.ClassInstances;
using LanguageExt.Common;
using LanguageExt.Pretty;
using LanguageExt.SomeHelp;
using static LanguageExt.Prelude;
public class Demo20240816_2
{
    public Func<byte[],byte[],int> TotalBytes = (byte[] a, byte[] b) => a.Length + b.Length;

    public Eff<byte[]> GetFile(string path)=>
    Eff(()=>File.ReadAllBytes(path))
    .MapFail(ex=>$"讀取檔案{path}發生錯誤:{ex.Message}");

    public Fin<int> GetFileTotalBytes(string path1,string path2)=>
    TotalBytes.Apply(GetFile(path1).Run(),GetFile(path2).Run());

}