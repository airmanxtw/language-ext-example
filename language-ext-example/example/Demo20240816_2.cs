namespace language_ext_example.example;

using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using LanguageExt;
using LanguageExt.ClassInstances;
using LanguageExt.Common;
using LanguageExt.Pretty;
using LanguageExt.SomeHelp;
using LanguageExt.UnsafeValueAccess;
using static LanguageExt.Prelude;
public class Demo20240816_2
{
    public Func<byte[], byte[], int> TotalBytes = (byte[] a, byte[] b) => a.Length + b.Length;

    public Eff<byte[]> GetFile(string path) =>
    Eff(() => File.ReadAllBytes(path))
    .MapFail(ex => $"讀取檔案{path}發生錯誤:{ex.Message}");

    public Fin<int> GetFileTotalBytes(string path1, string path2) =>
    TotalBytes.Apply(GetFile(path1).Run(), GetFile(path2).Run());

    public Eff<int> GetAllFileTotalBytes1(string[] paths) =>
    paths.Map(GetFile).Sequence().Map(v => v.Count());

    public int GetAllFileTotalBytes2(string[] paths) =>
    paths.Map(GetFile)
    .SequenceParallel<Eff<byte[]>, int>((b) => b.Run().Match(Succ: c => c.Length, Fail: _ => 0))
    .Map(v => v.Sum())
    .ValueUnsafe()
    .Result;


    // 這個很好用
    public int GetAllFileTotalBytes3(string[] paths)=>
    paths.Map(GetFile).Map(v => v.Run().Match(Succ: c => c.Length, Fail: _ => 0)).Sum();
    


}