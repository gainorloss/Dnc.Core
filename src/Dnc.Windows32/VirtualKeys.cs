using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Windows32
{
    /// <summary>
    /// 键盘动作枚举
    /// </summary>
    public enum VirtualKeys : byte
    {
        //VK_NUMLOCK = 0x90, //数字锁定键
        //VK_SCROLL = 0x91, //滚动锁定
        //VK_CAPITAL = 0x14, //大小写锁定
        //VK_A = 62, //键盘A
        VK_LBUTTON = 1, //鼠标左键
        VK_RBUTTON = 2,  //鼠标右键
        VK_CANCEL = 3,    //Ctrl+Break(通常不需要处理)
        VK_MBUTTON = 4,   //鼠标中键
        VK_BACK = 8,     //Backspace
        VK_TAB = 9,     //Tab
        VK_CLEAR = 12,    //Num Lock关闭时的数字键盘5
        VK_RETURN = 13,   //Enter(或者另一个)
        VK_SHIFT = 16,    //Shift(或者另一个)
        VK_CONTROL = 17,   //Ctrl(或者另一个）
        VK_MENU = 18,    //Alt(或者另一个)
        VK_PAUSE = 19,    //Pause
        VK_CAPITAL = 20,   //Caps Lock
        VK_ESCAPE = 27,   //Esc
        VK_SPACE = 32,    //Spacebar
        VK_PRIOR = 33,    //Page Up
        VK_NEXT = 34,    //Page Down
        VK_END = 35,     //End
        VK_HOME = 36,    //Home
        VK_LEFT = 37,    //左箭头
        VK_UP = 38,     //上箭头
        VK_RIGHT = 39,    //右箭头
        VK_DOWN = 40,    //下箭头
        VK_SELECT = 41,   //可选
        VK_PRINT = 42,    //可选
        VK_EXECUTE = 43,   //可选
        VK_SNAPSHOT = 44,  //Print Screen
        VK_INSERT = 45,   //Insert
        VK_DELETE = 46,   //Delete
        VK_HELP = 47,   //可选
        VK_NUM0 = 48, //0
        VK_NUM1 = 49, //1
        VK_NUM2 = 50, //2
        VK_NUM3 = 51, //3
        VK_NUM4 = 52, //4
        VK_NUM5 = 53, //5
        VK_NUM6 = 54, //6
        VK_NUM7 = 55, //7
        VK_NUM8 = 56, //8
        VK_NUM9 = 57, //9
        VK_A = 65, //A
        VK_B = 66, //B
        VK_C = 67, //C
        VK_D = 68, //D
        VK_E = 69, //E
        VK_F = 70, //F
        VK_G = 71, //G
        VK_H = 72, //H
        VK_I = 73, //I
        VK_J = 74, //J
        VK_K = 75, //K
        VK_L = 76, //L
        VK_M = 77, //M
        VK_N = 78, //N
        VK_O = 79, //O
        VK_P = 80, //P
        VK_Q = 81, //Q
        VK_R = 82, //R
        VK_S = 83, //S
        VK_T = 84, //T
        VK_U = 85, //U
        VK_V = 86, //V
        VK_W = 87, //W
        VK_X = 88, //X
        VK_Y = 89, //Y
        VK_Z = 90, //Z
        VK_NUMPAD0 = 96, //0
        VK_NUMPAD1 = 97, //1
        VK_NUMPAD2 = 98, //2
        VK_NUMPAD3 = 99, //3
        VK_NUMPAD4 = 100, //4
        VK_NUMPAD5 = 101, //5
        VK_NUMPAD6 = 102, //6
        VK_NUMPAD7 = 103, //7
        VK_NUMPAD8 = 104, //8
        VK_NUMPAD9 = 105, //9
        VK_NULTIPLY = 106,  //数字键盘上的*
        VK_ADD = 107,    //数字键盘上的+
        VK_SEPARATOR = 108, //可选
        VK_SUBTRACT = 109,  //数字键盘上的-
        VK_DECIMAL = 110,  //数字键盘上的.
        VK_DIVIDE = 111,   //数字键盘上的/
        VK_F1 = 112,
        VK_F2 = 113,
        VK_F3 = 114,
        VK_F4 = 115,
        VK_F5 = 116,
        VK_F6 = 117,
        VK_F7 = 118,
        VK_F8 = 119,
        VK_F9 = 120,
        VK_F10 = 121,
        VK_F11 = 122,
        VK_F12 = 123,
        VK_NUMLOCK = 144,  //Num Lock
        VK_SCROLL = 145   // Scroll Lock
    }
}
