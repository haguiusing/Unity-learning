# Console 控制台窗口

The **Console** Window displays errors, warnings, and other messages the Editor generates. These errors and warnings help you find issues in your project, such as script compilation errors. They also alert you to actions the Editor has taken automatically, such as replacing missing meta files, which could cause an issue somewhere else in your project.
**Console** 窗口显示 Editor 生成的错误、警告和其他消息。这些错误和警告可帮助您查找项目中的问题，例如脚本编译错误。它们还会提醒您 Editor 已自动执行的操作，例如替换缺少的元文件，这可能会导致项目中的其他位置出现问题。

To help you debug your project, use the [Debug](https://docs.unity3d.com/cn/current/Manual/class-Debug.html) class to print your own messages to the Console. For example, you can print the value of a variable at certain points in your script to see how they change.
为了帮助您调试项目，请使用 [Debug](https://docs.unity3d.com/cn/current/Manual/class-Debug.html) 类将您自己的消息输出到 Console。例如，您可以在脚本中的某些点打印变量的值，以查看它们如何变化。

This page covers the options you can use when you work with the Console window, and how you can filter your messages by searching for specific keywords.
本页介绍了在使用 Console （控制台） 窗口时可以使用的选项，以及如何通过搜索特定关键字来筛选消息。

## Console window interface/控制台窗口界面

To open the Console, from Unity’s main menu go to **Window** > **General** > **Console**.
要打开控制台，请从 Unity 的主菜单转到 **Window** > **General** > **Console**。

![](https://docs.unity3d.com/cn/current/uploads/Main/Console.png)

**A**. The Console **toolbar** has options for controlling how to display messages, and for [searching and filtering](https://docs.unity3d.com/cn/current/Manual/Console.html#search) messages.

**B**. The Console window menu has options for [opening Log files](https://docs.unity3d.com/cn/current/Manual/Console.html#log-file), controlling [how much of each message](https://docs.unity3d.com/cn/current/Manual/Console.html#line-count) is visible in the list, and setting stack trace options.

**C**. The Console list displays an entry for each logged message. Select a message to display its entire text in the detail area. You can choose how many lines of each message to display here. See [Adjusting the line count](https://docs.unity3d.com/cn/current/Manual/Console.html#line-count), below.

**D**. The detail area displays the full text of the selected message. If you enable stack trace, the detail area displays references to specific lines in code files as clickable links.

**A**.Console （控制台）工具栏具有用于控制消息显示方式以及[搜索和筛选](https://docs.unity3d.com/cn/current/Manual/Console.html#search)消息的选项。

**B**. Console （控制台） 窗口菜单包含用于[打开日志文件](https://docs.unity3d.com/cn/current/Manual/Console.html#log-file)、控制[每条消息](https://docs.unity3d.com/cn/current/Manual/Console.html#line-count)在列表中可见的数量以及设置堆栈跟踪选项的选项。

**C**. Console （控制台） 列表显示每条记录的消息的条目。选择一条消息以在详细信息区域中显示其整个文本。您可以选择在此处显示每条消息的行数。请参阅下面的[调整行数](https://docs.unity3d.com/cn/current/Manual/Console.html#line-count)。

**D**. 详细信息区域显示所选消息的全文。如果启用堆栈跟踪，则详细信息区域会将对代码文件中特定行的引用显示为可单击的链接。

## Console 工具栏选项

The toolbar of the Console window has options for controlling how to display messages, and for searching and filtering messages.
Console （控制台） 窗口的工具栏包含用于控制消息显示方式以及搜索和筛选消息的选项。
![[Pasted image 20240901120431.png]]
![[Pasted image 20240901120536.png]]
## Searching and filtering Console output

You can search Console messages for specific keywords from the Console search bar. As you type a search term, the Console filters messages to display only those that contain matching text. The Console highlights only the first match in the message text, and only if it’s in the visible part of the message (see [Adjusting the Line Count](https://docs.unity3d.com/cn/current/Manual/Console.html#line-count) below).
您可以从 Console 搜索栏中搜索特定关键字的 Console 消息。键入搜索词时，Console 会筛选消息以仅显示包含匹配文本的消息。控制台仅突出显示消息文本中的第一个匹配项，并且仅当它位于消息的可见部分时（请参阅下面的[调整行数](https://docs.unity3d.com/cn/current/Manual/Console.html#line-count)）。

![Searching for the term name highlights the first match in each message](https://docs.unity3d.com/cn/current/uploads/Main/ConsoleSearch.png)

Searching for the term “name” highlights the first match in each message
搜索词 “name” 会突出显示每条消息中的第一个匹配项

You can search for anything that appears in any Console message, including numerals and special characters. For example, you can search for the time the console logged a message.
您可以搜索任何 Console 消息中出现的任何内容，包括数字和特殊字符。例如，您可以搜索控制台记录消息的时间。

The search looks for exact matches of whatever you type in the search bar. You can’t search for two different terms at once, or use common search engine operators.
搜索将查找您在搜索栏中键入的任何内容的完全匹配项。您不能同时搜索两个不同的词，也不能使用常见的搜索引擎运算符。

You can also filter Console messages by type. Click the buttons beside the search bar to toggle:
您还可以按类型筛选 Console 消息。单击搜索栏旁边的按钮进行切换：

|**按钮**|**功能**|
|---|---|
|![](https://docs.unity3d.com/cn/current/uploads/Main/ConsoleFilterMessage.png)  <br>  <br>**Messages switch**|Displays the number of messages in the Console. Click to display or hide messages.|
|![](https://docs.unity3d.com/cn/current/uploads/Main/ConsoleFilterWarning.png)  <br>  <br>**Warnings switch**|Displays the number of warnings in the Console. Click to display or hide warnings.|
|![](https://docs.unity3d.com/cn/current/uploads/Main/ConsoleFilterError.png)  <br>  <br>**Errors switch**|Displays the number of errors in the Console. Click to display or hide errors.|

## Adjusting the line count/调整行数

每个控制台条目的最大长度为 10 行。

To control how many lines of each entry are visible in the list, click the Console menu button, and select **Log Entry** > **[X] Lines** from the menu, where **[X]** is the number of lines to display for each entry.
要控制每个条目在列表中可见的行数，请单击 Console 菜单按钮，然后从菜单中选择 **Log Entry** > **[X] Lines**，其中 **[X]** 是为每个条目显示的行数。
![日志条目行计数](https://docs.unity3d.com/cn/current/uploads/Main/ConsoleAdjustLineCount.png)

日志条目行计数

A larger line count displays more of the text of each entry, but reduces the number of entries visible at any given time. The line count doesn’t affect the Console search function, which always searches the full message text. If the matching text is on a hidden line, the search returns the message in the results, but doesn’t expand it to reveal or highlight the matching text. You can see the full message text in the detail area, but the matching text isn’t highlighted there.
较大的行数显示每个条目的更多文本，但会减少在任何给定时间可见的条目数。行数不会影响 Console 搜索功能，该功能始终搜索完整的消息文本。如果匹配的文本位于隐藏行上，则搜索将在结果中返回消息，但不会展开它以显示或突出显示匹配的文本。您可以在详细信息区域中看到完整的消息文本，但匹配的文本不会在此处突出显示。

## 堆栈跟踪日志记录

Unity Console messages and log files can include detailed stack trace information. You can control the amount of stack trace information using the [stack trace logging](https://docs.unity3d.com/cn/current/Manual/StackTrace.html) settings.
Unity 控制台消息和日志文件可以包含详细的堆栈跟踪信息。您可以使用 [Stack trace logging （堆栈跟踪日志记录](https://docs.unity3d.com/cn/current/Manual/StackTrace.html)） 设置来控制堆栈跟踪信息的数量。
## Opening Log files from the Console

Everything Unity or your code write to the Console Window is also written to a [Log File](https://docs.unity3d.com/cn/current/Manual/LogFiles.html). You can open Log files from the Console window menu. Select **Open Player Log** or **Open Editor Log**.
Unity 或您的代码写入 Console 窗口的所有内容也会写入[日志文件](https://docs.unity3d.com/cn/current/Manual/LogFiles.html)。您可以从 Console （控制台） 窗口菜单打开 Log files （日志文件）。选择 **Open Player Log** 或 **Open Editor Log**。