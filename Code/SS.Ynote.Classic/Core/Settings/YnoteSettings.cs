#define DEVBUILD

using System.IO;
using System.Text;
using FastColoredTextBoxNS;
using Nini.Config;
using WeifenLuo.WinFormsUI.Docking;
#if PORTABLE
    using System.Windows.Forms;
#else
using System;

#endif

/// <summary>
///     Contains all the YnoteSettings for Ynote
/// </summary>
public static class YnoteSettings
{
#if !PORTABLE

    internal static readonly string SettingsDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                                  @"\Ynote_Classic\";
#else
    internal static readonly string SettingsDir = Application.StartupPath + @"\Package\";
#endif
#if DEVBUILD

    internal static int BuildNumber { get; set; }

#endif
    internal static string SettingsFile = SettingsDir + "User.ynotesettings";

    /// <summary>
    ///     Theme File
    /// </summary>
    public static string ThemeFile { get; set; }

    /// <summary>
    ///     Show Hidden Chars
    /// </summary>
    public static bool HiddenChars { get; set; }

    /// <summary>
    ///     Document Style
    /// </summary>
    internal static DocumentStyle DocumentStyle { get; set; }

    /// <summary>
    ///     Get the Tab Location
    /// </summary>
    internal static DocumentTabStripLocation TabLocation { get; set; }

    /// <summary>
    ///     Show Folding Lines
    /// </summary>
    internal static bool ShowFoldingLines { get; set; }

    /// <summary>
    ///     Show Caret
    /// </summary>
    internal static bool ShowCaret { get; set; }

    /// <summary>
    ///     Highlight Folding
    /// </summary>
    public static bool HighlightFolding { get; set; }

    /// <summary>
    ///     Show Document Map
    /// </summary>
    public static bool ShowDocumentMap { get; set; }

    /// <summary>
    ///     Show Ruler
    /// </summary>
    internal static bool ShowRuler { get; set; }

    /// <summary>
    ///     Whether to Show Line Numbers
    /// </summary>
    internal static bool ShowLineNumbers { get; set; }

    /// <summary>
    ///     Enable Virtual Space
    /// </summary>
    internal static bool EnableVirtualSpace { get; set; }

    /// <summary>
    ///     Folding Strategy
    /// </summary>
    internal static FindEndOfFoldingBlockStrategy FoldingStrategy { get; set; }

    /// <summary>
    ///     Bracket Highlighting Strategy
    /// </summary>
    internal static BracketsHighlightStrategy BracketsStrategy { get; set; }

    /// <summary>
    ///     Line Interval
    /// </summary>
    /// y>
    public static int PaddingWidth { get; set; }

    /// <summary>
    ///     Show Status Bar
    /// </summary>
    public static int LineInterval { get; set; }

    /// <summary>
    ///     Show Status Bar
    /// </summary>
    internal static bool ShowStatusBar { get; set; }

    /// <summary>
    ///     Show MenuBar
    /// </summary>
    internal static bool ShowMenuBar { get; set; }

    /// <summary>
    ///     Font-Family
    /// </summary>
    internal static string FontFamily { get; private set; }

    /// <summary>
    ///     No. of RecentFiles
    /// </summary>
    internal static int RecentFileNumber { get; set; }

    /// <summary>
    ///     Font Size
    /// </summary>
    internal static float FontSize { get; private set; }

    /// <summary>
    ///     Zoom
    /// </summary>
    internal static int TabSize { get; set; }

    /// <summary>
    ///     Autocomplete Brackets
    /// </summary>
    internal static int Zoom { get; set; }

    /// <summary>
    ///     Loads YnoteSettings
    /// </summary>
    internal static bool AutoCompleteBrackets { get; set; }

    /// <summary>
    ///     Checks if WordWrap is on
    /// </summary>
    internal static bool WordWrap { get; set; }

    /// <summary>
    ///     Gets The Default Encoding for Saving Document
    /// </summary>
    internal static int DefaultEncoding { get; set; }

    /// <summary>
    ///     Show the Tool Bar
    /// </summary>
    internal static bool ShowToolBar { get; set; }

    /// <summary>
    ///     Whether to Minimize app to System Tray
    /// </summary>
    internal static bool MinimizeToTray { get; set; }

    /// <summary>
    ///     Whether to Highlight Same Words
    /// </summary>
    internal static bool HighlightSameWords { get; set; }

    /// <summary>
    ///     Whether to show Changed Line
    /// </summary>
    internal static bool ShowChangedLine { get; set; }

    /// <summary>
    ///     Whether IME mode is on
    /// </summary>
    internal static bool IMEMode { get; set; }

    /// <summary>
    ///     Block Cursor is On
    /// </summary>
    internal static bool BlockCaret { get; set; }

    /// <summary>
    ///     Whether to use Tabs vs Spaces
    /// </summary>
    internal static bool UseTabs { get; set; }

    /// <summary>
    ///     Whether to show Scroll Bars
    /// </summary>
    internal static bool ScrollBars { get; set; }

    /// <summary>
    ///     Loads YnoteSettings
    /// </summary>
    internal static void Load()
    {
        if (File.Exists(SettingsFile))
        {
            IConfigSource source = new IniConfigSource(SettingsFile);
            IConfig config = source.Configs["Ynote"];
            ThemeFile = config.Get("ThemeFile");
            HiddenChars = config.GetBoolean("ShowHiddenCharacters");
            DocumentStyle = config.Get("DocumentStyle").ToEnum<DocumentStyle>();
            TabLocation = config.Get("TabLocation").ToEnum<DocumentTabStripLocation>();
            BracketsStrategy = config.Get("BracketStrategy").ToEnum<BracketsHighlightStrategy>();
            FoldingStrategy = config.Get("FoldingStrategy").ToEnum<FindEndOfFoldingBlockStrategy>();
            ShowCaret = config.GetBoolean("ShowCaret");
            ShowDocumentMap = config.GetBoolean("ShowDocumentMap");
            ShowRuler = config.GetBoolean("ShowRuler");
            AutoCompleteBrackets = config.GetBoolean("AutocompleteBrackets");
            ShowFoldingLines = config.GetBoolean("ShowFoldingLines");
            ShowLineNumbers = config.GetBoolean("ShowLineNumbers");
            EnableVirtualSpace = config.GetBoolean("EnableVirtualSpace");
            HighlightFolding = config.GetBoolean("HighlightFolding");
            PaddingWidth = config.GetInt("PaddingWidth");
            LineInterval = config.GetInt("LineInterval");
            DefaultEncoding = config.GetInt("Encoding");
            ShowStatusBar = config.GetBoolean("StatusBar");
            ShowToolBar = config.GetBoolean("ToolBar");
            ShowMenuBar = config.GetBoolean("MenuBar");
            BlockCaret = config.GetBoolean("BlockCaret");
            FontFamily = config.Get("FontFamily");
            ScrollBars = config.GetBoolean("ScrollBars");
            ShowChangedLine = config.GetBoolean("ChangedLine");
            WordWrap = config.GetBoolean("Wordwrap");
            FontSize = config.GetFloat("FontSize");
            HighlightSameWords = config.GetBoolean("HighlightSameWords");
            TabSize = config.GetInt("TabSize");
            RecentFileNumber = config.GetInt("RecentFilesNo");
            MinimizeToTray = config.GetBoolean("MinimizeToTray");
            UseTabs = config.GetBoolean("UseTabs");
            IMEMode = config.GetBoolean("IMEMode");
            Zoom = config.GetInt("Zoom");
        }
        else
        {
            File.WriteAllText(SettingsFile, string.Empty);
            RestoreDefault();
            Load();
        }
    }

    /// <summary>
    ///     Save Script
    /// </summary>
    public static void Save()
    {
        IConfigSource source = new IniConfigSource(SettingsFile);
        IConfig config = source.Configs["Ynote"];
        config.Set("ThemeFile", ThemeFile);
        config.Set("ShowHiddenCharacters", HiddenChars);
        config.Set("DocumentStyle", DocumentStyle);
        config.Set("TabLocation", TabLocation);
        config.Set("BracketStrategy", BracketsStrategy);
        config.Set("FoldingStrategy", FoldingStrategy);
        config.Set("ShowCaret", ShowCaret);
        config.Set("ShowDocumentMap", ShowDocumentMap);
        config.Set("ShowRuler", ShowRuler);
        config.Set("ShowFoldingLines", ShowFoldingLines);
        config.Set("ShowLineNumbers", ShowLineNumbers);
        config.Set("AutocompleteBrackets", AutoCompleteBrackets);
        config.Set("EnableVirtualSpace", EnableVirtualSpace);
        config.Set("HighlightFolding", HighlightFolding);
        config.Set("PaddingWidth", PaddingWidth);
        config.Set("ChangedLine", ShowChangedLine);
        config.Set("LineInterval", LineInterval);
        config.Set("RecentFilesNo", RecentFileNumber);
        config.Set("StatusBar", ShowStatusBar);
        config.Set("ScrollBars", ScrollBars);
        config.Set("ToolBar", ShowToolBar);
        config.Set("HighlightSameWords", HighlightSameWords);
        config.Set("MenuBar", ShowMenuBar);
        config.Set("FontFamily", FontFamily);
        config.Set("FontSize", FontSize);
        config.Set("BlockCaret", BlockCaret);
        config.Set("UseTabs", UseTabs);
        config.Set("Encoding", DefaultEncoding);
        config.Set("Wordwrap", WordWrap);
        config.Set("MinimizeToTray", MinimizeToTray);
        config.Set("IMEMode", IMEMode);
        config.Set("Zoom", Zoom);
        source.Save();
    }

    private static void RestoreDefault()
    {
        IConfigSource source = new IniConfigSource(SettingsFile);
        IConfig config = source.AddConfig("Ynote");
        config.Set("ThemeFile", SettingsDir + @"User\Themes\Default.ynotetheme");
        config.Set("ShowHiddenCharacters", false);
        config.Set("DocumentStyle", DocumentStyle.DockingMdi);
        config.Set("TabLocation", DocumentTabStripLocation.Top);
        config.Set("BracketStrategy", BracketsHighlightStrategy.Strategy2);
        config.Set("FoldingStrategy", FindEndOfFoldingBlockStrategy.Strategy1);
        config.Set("ShowCaret", true);
        config.Set("BlockCaret", false);
        config.Set("ShowDocumentMap", true);
        config.Set("ShowRuler", false);
        config.Set("ShowFoldingLines", true);
        config.Set("ShowLineNumbers", true);
        config.Set("AutocompleteBrackets", true);
        config.Set("EnableVirtualSpace", false);
        config.Set("HighlightFolding", true);
        config.Set("ScrollBars", true);
        config.Set("ChangedLine", false);
        config.Set("PaddingWidth", 18);
        config.Set("LineInterval", 0);
        config.Set("RecentFilesNo", 15);
        config.Set("MenuBar", true);
        config.Set("StatusBar", true);
        config.Set("ToolBar", false);
        config.Set("MinimizeToTray", false);
        config.Set("HighlightSameWords", true);
        config.Set("Wordwrap", false);
        config.Set("IMEMode", false);
        config.Set("UseTabs", false);
        config.Set("Encoding", Encoding.Default.CodePage);
        config.Set("FontFamily", "Consolas");
        config.Set("FontSize", 9.75F);
        config.Set("TabSize", 4);
        config.Set("Zoom", 100);
        source.Save();
    }
}