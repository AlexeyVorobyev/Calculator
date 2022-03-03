using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class Summator
{
    int pow(int a,int b)
    {
        if (b != 0) return pow(a, b - 1) * a;
        else return 1;
    }

    public string erase(string x, int a, int b)
    {
        string res = "";
        for (int i = 0; i < x.Length; i++) if (i < a || i >= a + b) res += x[i];
        return res;
    }

    public string int_to_string(int x)
    {
        string res = "";
        bool flag = false;
        if (x < 0) {
            flag = true;
            x = x * -1;
        }
        while (x != 0)
        {
            res = ((char)x % 10) + res;
            x /= 10;
        }
        if (flag) res = "(-" + res + ')';

        return res;
    }

    public int string_to_int(string x)
    {
        int res = 0;
        bool flag = false;
        if (x[0] == '-')
        {
            flag = true;
            x = erase(x, 0, 1);
        }
        for (int i = 0, j = x.Length - 1; i < x.Length; i++, j--) res += ((int)x[i] - 48) * pow(10, j);
        if (flag) res = -1 * res;
        return res;
    }

    public string binary_8(int x)
    {
        string res = "";
        int temp;
        if (x < 0) temp = -1 * x;
        else temp = x;
        while (temp != 0)
        {
            res = (char)(temp % 2 + 48) + res;
            temp /= 2;
        }
        if (res.Length < 8) while (res.Length != 8) res = '0' + res;
        if (x < 0) res = '1' + erase(res, 0, 1);
        return res;
    }

    public int decim (string x) {
	    int res = 0;
	    for (int i = x.Length - 1, j = 0; i > 0; i--, j++) if (x[i] == '1') res += pow(2, j);
	    if (x[0] == '1') res = res* (-1);
	    return res;
    }

    public string summator_easy(string bin_a, string bin_b)
    {
        string bin_c = binary_8(0);
        bool trans = false;
        for (int i = bin_a.Length - 1; i >= 0; i--)
        {
            if (trans == false)
            {
                if (bin_a[i] == '1' && bin_b[i] == '1')
                {
                    bin_c = erase(bin_c, i, bin_c.Length) + '0' + erase(bin_c, 0, i+1);
                    trans = true;
                }
                else if (bin_a[i] == '0' && bin_b[i] == '1' || bin_a[i] == '1' && bin_b[i] == '0') bin_c = erase(bin_c, i, bin_c.Length) + '1' + erase(bin_c, 0, i+1);
                else
                {
                    bin_c = erase(bin_c, i, bin_c.Length) + '0' + erase(bin_c, 0, i+1);
                }
            }
            else
            {
                if (bin_a[i] == '1' && bin_b[i] == '1') bin_c = erase(bin_c, i, bin_c.Length) + '1' + erase(bin_c, 0, i+1);
                else if (bin_a[i] == '0' && bin_b[i] == '1' || bin_a[i] == '1' && bin_b[i] == '0') bin_c = erase(bin_c, i, bin_c.Length) + '0' + erase(bin_c, 0, i+1);
                else
                {
                    bin_c = erase(bin_c, i, bin_c.Length) + '1' + erase(bin_c, 0, i+1);
                    trans = false;
                }
            }
        }
        return bin_c;
    }

    public string dop_coderator(string x)
    {
        for (int i = x.Length - 1; i > 0; i--)
        {
            if (x[i] == '0') x = erase(x, i, x.Length) + '1' + erase(x, 0, i+1);
            else x = erase(x, i, x.Length) + '0' + erase(x, 0, i+1);
        }
        return summator_easy(x, binary_8(1));
    }

    public string dop_decoderator(string x)
    {
        for (int i = x.Length - 1; i > 0; i--)
        {
            if (x[i] == '1') x = erase(x, i, x.Length) + '0' + erase(x, 0, i+1);
            else x = erase(x, i, x.Length) + '1' + erase(x, 0, i+1);
        }
        return summator_easy(x, binary_8(1));
    }

    public string summator(string bin_a, string bin_b)
    {
        string bin_c = binary_8(0);
        if (bin_a[0] == '1') bin_a = dop_coderator(bin_a);
        if (bin_b[0] == '1') bin_b = dop_coderator(bin_b);
        bool trans = false;
        for (int i = bin_a.Length - 1; i >= 0; i--)
        {
            if (trans == false)
            {
                if (bin_a[i] == '1' && bin_b[i] == '1')
                {
                    bin_c = erase(bin_c, i, bin_c.Length) + '0' + erase(bin_c, 0, i+1);
                    trans = true;
                }
                else if (bin_a[i] == '0' && bin_b[i] == '1' || bin_a[i] == '1' && bin_b[i] == '0') bin_c = erase(bin_c, i, bin_c.Length) + '1' + erase(bin_c, 0, i+1);
                else bin_c = erase(bin_c, i, bin_c.Length) + '0' + erase(bin_c, 0, i+1);
            }
            else
            {
                if (bin_a[i] == '1' && bin_b[i] == '1') bin_c = erase(bin_c, i, bin_c.Length) + '1' + erase(bin_c, 0, i+1);
                else if (bin_a[i] == '0' && bin_b[i] == '1' || bin_a[i] == '1' && bin_b[i] == '0') bin_c = erase(bin_c, i, bin_c.Length) + '0' + erase(bin_c, 0, i+1);
                else
                {
                    bin_c = erase(bin_c, i, bin_c.Length) + '1' + erase(bin_c, 0, i+1);
                    trans = false;
                }
            }
        }
        if (bin_c[0] == '1') bin_c = dop_decoderator(bin_c);
        return bin_c;
    }
}

public class Calculator : MonoBehaviour
{
    private string erase(string x,int a, int b)
    {
        string res = "";
        for (int i = 0; i < x.Length;i++) if (i < a || i >= a + b) res += x[i];
        return res;
    }

    public Text input;
    public Image[] images;
    
    void Start()
    {
        Debug.Log("we here");
    }



    public void on_click_figure_button()
    {
        string value = EventSystem.current.currentSelectedGameObject.name;
        input.text += value;
    }

    public void on_click_clear_button()
    {
        input.text = "";
        for (int i = 0; i < 8; i++)
        {
            images[7 - i].color = new Color(0.3f, 0.3f, 0.3f, images[i].color.a);
        }
    }

    public void on_click_minus_button()
    {
        bool flag = true;
        for (int i = input.text.Length - 1; i >= 0; i--)
        {
            if (input.text[i] == '+')
            {
                flag = false;
                if (input.text[i + 1] != '(')
                {
                    input.text = input.text.Insert(i + 1, "(-");
                    input.text = input.text + ")";
                    break;
                }
                else
                {
                    input.text = erase(input.text, i + 1, 2);
                    input.text = erase(input.text, input.text.Length - 1, 1);
                    break;
                }

            }
        }
        if (flag)
        {
            if (input.text[0] != '(')
            {
                input.text = "(-" + input.text + ")";
            }
            else
            {
                input.text = erase(input.text, 0, 2);
                input.text = erase(input.text, input.text.Length - 1, 1);
            }
        }
    } 

    public void on_click_plus_button()
    {
        if (input.text.Length != 0) if (input.text[input.text.Length - 1] != '+') input.text += '+';
    }

    public void on_click_result_button()
    {
        Summator sm = new Summator();
        int point = -1;
        for (int i = 0; i < input.text.Length; i++) if (input.text[i] == '+') point = i;
        if (point != -1)
        {
            string b = erase(input.text, 0, point + 1);
            string a = erase(input.text, point, input.text.Length);
            if (a[0] == '(')
            {
                a = erase(a, a.Length - 1, a.Length);
                a = erase(a, 0, 1);
            }
            if (b[0] == '(')
            {
                b = erase(b, b.Length - 1, b.Length);
                b = erase(b, 0, 1);
            }
            string resulted_str = sm.summator(sm.binary_8(sm.string_to_int(a)), sm.binary_8(sm.string_to_int(b)));
            Debug.Log(sm.summator(sm.binary_8(sm.string_to_int(a)), sm.binary_8(sm.string_to_int(b))));
            input.text = sm.int_to_string(sm.decim(resulted_str));
            for (int i = 0; i < 8; i++)
            {
                if (resulted_str[i] == '1')
                {
                    if (i != 0) images[7 - i].color = new Color(0.9f, 0.9f, 0.9f, images[i].color.a);
                    else images[7 - i].color = new Color(0.9f, 0.9f, 0.1f, images[i].color.a);
                }
                else images[7 - i].color = new Color(0.3f, 0.3f, 0.3f, images[i].color.a);
            }


        }
        else {
            string a = input.text;
            if (a[0] == '(')
            {
                a = erase(a, a.Length - 1, a.Length);
                a = erase(a, 0, 1);
            }
            string resulted_str = sm.binary_8(sm.string_to_int(a));
            for (int i = 0; i < 8; i++)
            {
                if (resulted_str[i] == '1')
                {
                    if (i != 0) images[7 - i].color = new Color(0.9f, 0.9f, 0.9f, images[i].color.a);
                    else images[7 - i].color = new Color(0.9f, 0.9f, 0.1f, images[i].color.a);
                }
                else images[7 - i].color = new Color(0.3f, 0.3f, 0.3f, images[i].color.a);
            }
        }
    }
}
