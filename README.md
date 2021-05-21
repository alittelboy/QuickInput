# QuickInput
An app to accelerate keyboard input in Windows. 

思路来自于星际争霸的快捷键**编队**思想。

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
直接修改QuickInputSet.ini文件

## 方法2：
使用快捷键修改**编队**，会自动保存到对应文件。



# 速查表

KeyCode：

https://www.bejson.com/othertools/keycodes/

SendKeys

https://www.cnblogs.com/shaozhuyong/p/5951779.html
