using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// 文字列管理クラス(多言語対応)
/// </summary>
public static class TextManager
{
    // 文字列格納、検索用ディクショナリー
    private static Dictionary<string, string> sDictionary = new Dictionary<string, string>();

    /// <summary>
    /// 検索キー
    /// </summary>
    public enum KEY
    {
        MAZE,
        START,
        GOAL,
        SIZE,
        PAUSE,
        GAMEOVER,
        GAMECLEAR,
    };

    /// <summary>
    /// 使用言語
    /// </summary>


    /// <summary>
    /// 文字列初期化
    /// </summary>
    /// <param name="lang">使用言語</param>
    public static void Init(SystemLanguage lang)
    {
        // リソースファイルパス決定
        string filePath;
        if (lang == SystemLanguage.Japanese)
        {
            filePath = "Text/japanese";
        }
        else if (lang == SystemLanguage.English)
        {
            filePath = "Text/english";
        }
        else if (lang == SystemLanguage.ChineseSimplified)
        {
            filePath = "Text/chinesesimplified";
        }
        else if (lang == SystemLanguage.ChineseTraditional)
        {
            filePath = "Text/chinesetraditional";
        }
        else if (lang == SystemLanguage.French)
        {
            filePath = "Text/french";
        }
        else if (lang == SystemLanguage.German)
        {
            filePath = "Text/german";
        }
        else if (lang == SystemLanguage.Italian)
        {
            filePath = "Text/italian";
        }
        else if (lang == SystemLanguage.Korean)
        {
            filePath = "Text/korean";
        }
        else if (lang == SystemLanguage.Portuguese)
        {
            filePath = "Text/portuguese";
        }
        else if (lang == SystemLanguage.Russian)
        {
            filePath = "Text/russian";
        }
        else if (lang == SystemLanguage.Spanish)
        {
            filePath = "Text/spanish";
        }
        else
        {
            filePath = "Text/english";
        }

        // ディクショナリー初期化
        sDictionary.Clear();
        TextAsset csv = Resources.Load<TextAsset>(filePath);
        StringReader reader = new StringReader(csv.text);
        while (reader.Peek() > -1)
        {
            string[] values = reader.ReadLine().Split('\t');
            sDictionary.Add(values[0], values[1].Replace("\\n", "\n"));
        }
    }

    /// <summary>
    /// 文字列取得
    /// </summary>
    /// <param name="key">文字列取得キー</param>
    /// <returns>キーに該当する文字列</returns>
    public static string Get(KEY key)
    {
        return Get(Enum.GetName(typeof(KEY), key));
    }

    /// <summary>
    /// 文字列取得
    /// </summary>
    /// <param name="key">文字列取得キー</param>
    /// <returns>キーに該当する文字列</returns>
    public static string Get(string key)
    {
        return sDictionary[key];
    }
}