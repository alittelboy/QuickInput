# QuickInput
设置**编队**和调用来快速输入文本、或快速打开文件或指令，的辅助程序。用以加速桌面工作效率。

An app to accelerate keyboard input in Windows. 

例如，配置好以后，你可以按键“空格+q”就可以在当前输入框自动输入你的QQ邮箱；tab切换到密码输入；“空格+p”就可以在当前输入框自动输入你的密码。这种输入方法可以大大的缩短用户的输入时间。

本软件的最终目的是在Windows里减少用户打字时间，和减少鼠标点击操作。本软件的创造思路来自于星际争霸的快捷键**编队**思想。

# 1.6 版本更新
 - 新增功能，设置-设置编队内容。新增一个设置窗体，可以可视化的设置编队内容。
 - 修改图标：请了设计师，修改了软件图标，现在和软件内容有更强的相关性。
 - 修改功能：现在设置目录下新增了“按键码实时显示”按钮，默认处于打开状态，可以在主窗体和设置窗体上，查看实时的按键码。
 - 新增功能，配置文件目录本地化：现在修改配置文件的位置（打开、另存为）后，下次打开软件会默认还是那个位置。
 - 新增功能，快捷键主键本地化：现在快捷键主键（默认空格）的修改（测试模式）已经本地化，下次打开也存在。
 - 新增功能，时间设置本地化：现在计时器时间间隔的修改（测试模式）已经本地化，下次打开也存在。

# 使用方法：
## 快捷输入
空格 + 字母/数字/其他键盘按键：根据设置自动发送对应**编队**存储的按键。

原理：输出两个退格（Backspace），然后输出内容。

## 快捷编队
Ctrl + 数字： 将当前选中内容复制，并添加到数字对应的**编队**。

原理：输出Ctrl C，然后修改**编队**。

## 增加到**编队**
Ctrl + Shift + 数字： 将当前选中内容复制到剪切板，并添加到**编队**保存的内容的后面。

原理：输出Ctrl C，然后添加到**编队**。

# 设置方法：

## 方法1：
主窗体点击“设置-设置编队内容”，或右键托盘-设置

## 方法2：
使用快捷键修改**编队**，会自动保存到对应文件。

## 方法3：
直接修改QuickInputSet.ini文件


# 修改配置文件 与 高级功能
## 配置文件
修改配置文件的格式是“按键码=编队内容”。需要在“[words]”字段下写入，每一行表示一个记录。
例如：
```ini
[words]
65=1234
73 = 176.5.14.88
```
上述配置文件表示：编队a（按键码65）对应字符串“1234”，因此输入“空格+a”即可输入1234。编队i（按键码73）对应字符串“176.5.14.88”，因此输入“空格+i”即可输入176.5.14.88。你可以在软件里标题里，轻松的查看现在按键对应的按键码，也可以点击“关于-按键码查询网站”查看全部的按键码。


## 高级功能
 - 打开文件：将编队设置为文件地址，调用编队即可打开文件。例如：
 ```ini
 65=D:\\myfile.txt
 ```
 - 打开文件夹：将编队设置为文件夹地址，调用编队即可打开文件夹。例如：
 ```ini
 65=D:\\
 ```
 - 打开网页：将编队设置为完整的网页地址（http或https），调用编队即可打开网页。例如：
 ```ini
 65=https://www.baidu.com/
 ```
-运行指令：将编队设置为开头“QuickInputRun:”，调用编队即可执行指令。例如：
```ini
65=QuickInputRun:cmd
```

# 新功能

## 1.6 版本更新
 - 新增功能，设置-设置编队内容。新增一个设置窗体，可以可视化的设置编队内容。
 - 修改图标：请了设计师，修改了软件图标，现在和软件内容有更强的相关性。
 - 修改功能：现在设置目录下新增了“按键码实时显示”按钮，默认处于打开状态，可以在主窗体和设置窗体上，查看实时的按键码。
 - 新增功能，配置文件目录本地化：现在修改配置文件的位置（打开、另存为）后，下次打开软件会默认还是那个位置。
 - 新增功能，快捷键主键本地化：现在快捷键主键（默认空格）的修改（测试模式）已经本地化，下次打开也存在。
 - 新增功能，时间设置本地化：现在计时器时间间隔的修改（测试模式）已经本地化，下次打开也存在。


## 1.5 版本更新
 - 新增功能，设置-设置右键发送到快捷键。设置以后，可以快速设置快捷键打开文件/文件夹
 - 新增功能：防重复启动。使用互斥锁实现。
 - 新增功能：自动重启：右键发送到快捷键后，会通过生成本地bat的方式自动重启。
 - 优化了代码结构，使得多个窗体和类之间共享数据，而不是每个存一份。
 - 优化了代码结构，使用字典(dictionary)代替了数组存储。

## 1.4 版本更新
 - 修改了目录结构，现在更加合理了。
 - 新增功能，打开文件：将编队设置为文件地址，调用编队即可打开文件。例如：65=D:\\myfile.txt
 - 新增功能，打开文件夹：将编队设置为文件夹地址，调用编队即可打开文件夹。例如：65=D:\\
 - 新增功能，打开网页：将编队设置为完整的网页地址（http或https），调用编队即可打开网页。例如：65=https://www.baidu.com/
-新增功能，运行指令：将编队设置为开头“QuickInputRun:”，调用编队即可执行指令。例如：65=QuickInputRun:cmd
 
 
## 1.3 版本更新
 - 新增了导入设置文件，另存为设置文件
 - 新增了测试模式下，可以修改检测的时间间隔
 - 新增了测试模式下，可以修改热键，来替代快捷键，建议输入可以被2个退格删掉的按键

## 1.2 版本更新
 - 新增托盘模式，点×不会直接关闭，而是到右下角托盘
 - 去掉了杂乱的按键，换成了顶部菜单
 - 现在可以设置开机启动
 - 现在可以启动时是否显示窗体
 - 修改了图标


## 1.1 版本更新
 - 完善测试模式，可以修改设置文件地址
 - 改善快捷键逻辑，按下触发而不是抬起，解决部分中文输入法空格时的误触发
 - 新增2个按钮，帮助用户快速使用


# 速查表

KeyCode：

https://www.bejson.com/othertools/keycodes/

SendKeys

https://www.cnblogs.com/shaozhuyong/p/5951779.html
