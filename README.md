# Ikst.EmbeddedResourceReader

## usefulness
プロジェクト中に含まれる「埋め込みリソース」に指定したファイルを読み込むのに使用します。
SQLファイルを埋め込みファイルとして外出しておく場合などに有用です。

## usage
Assemblyクラスの拡張メソッドです。
リソースを埋め込んだAssemblyを取得して下記の様に利用します。

> using Ikst.EmbeddedResourceReader;
> 
> var asm = System.Reflection.Assembly.GetExecutingAssembly();
> var resTxt = asm.GetEmbeddedResourceString("TestResource.TextFile1.txt");

※上記コードは下記の「TextFile1.txt」をテキストとして読み込む際のものです。
ファイルはプロパティで「埋め込みリソース」として設定しておく必要があります。

![GitHub_Readme1](https://user-images.githubusercontent.com/9896145/105632242-8043d800-5e95-11eb-8c51-37c4196a63ca.png) ![GitHub_Readme2](https://user-images.githubusercontent.com/9896145/105632264-8e91f400-5e95-11eb-9e61-90c57910c24c.png)
