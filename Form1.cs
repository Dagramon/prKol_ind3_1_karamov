using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace prKol_ind3_1_karamov
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ArrayList arrays = new ArrayList();
        int count = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != string.Empty)
                {
                    OneArray arr = new OneArray();
                    string[] numbers = textBox1.Text.Split(' ');
                    int[] nums = new int[numbers.Length];
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        nums[i] = Convert.ToInt32(numbers[i]);
                    }
                    arr.CreateArray(nums);
                    comboBox1.Items.Add($"Массив {count}");
                    comboBox2.Items.Add($"Массив {count}");
                    comboBox3.Items.Add($"Массив {count}");
                    count++;
                    arrays.Add(arr);
                }
                else
                {
                    MessageBox.Show("Поле не может быть пустым");
                }
            }
            catch
            {
                MessageBox.Show("Неверный формат ввода");
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            OneArray arr = (OneArray)arrays[comboBox1.SelectedIndex];
            for (int i = 0; i < arr.Array.Length; i++)
            {
                listBox1.Items.Add(arr.Array[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OneArray arr = (OneArray)arrays[comboBox1.SelectedIndex];
                label2.Text = arr.Array[listBox1.SelectedIndex].ToString();
            }
            catch
            {
                MessageBox.Show("Не выбран элемент");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                listBox2.Items.Clear();
                if (comboBox2.Text != string.Empty && comboBox3.Text != string.Empty)
                {
                    OneArray arr1 = (OneArray)arrays[comboBox2.SelectedIndex];
                    OneArray arr2 = (OneArray)arrays[comboBox3.SelectedIndex];
                    int[] result = arr1.Array.Concat(arr2.Array).ToArray();
                    for (int i = 0; i < result.Length; i++)
                    {
                        listBox2.Items.Add(result[i]);
                    }
                }
                else
                {
                    MessageBox.Show("Сначала нужно выбрать массивы");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                listBox2.Items.Clear();
                if (comboBox2.Text != string.Empty && comboBox3.Text != string.Empty)
                {
                    OneArray arr1 = (OneArray)arrays[comboBox2.SelectedIndex];
                    OneArray arr2 = (OneArray)arrays[comboBox3.SelectedIndex];
                    int[] result = arr1.Array.Except(arr2.Array).ToArray();
                    for (int i = 0; i < result.Length; i++)
                    {
                        listBox2.Items.Add(result[i]);
                    }
                }
                else
                {
                    MessageBox.Show("Сначала нужно выбрать массивы");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OneArray arrnew = new OneArray();
            if (comboBox1.Text != string.Empty)
            {
                OneArray arr = (OneArray)arrays[comboBox1.SelectedIndex];
                for (int i = 0; i < arr.Array.Length; i++)
                {
                    arr.Array[i] = arr.Array[i] * Convert.ToInt16(numericUpDown1.Value);
                }
                arrnew.CreateArray(arr.Array);
                arrays.RemoveAt(comboBox1.SelectedIndex);
                arrays.Insert(comboBox1.SelectedIndex, arr);
                listBox1.Items.Clear();
                for (int i = 0; i < arr.Array.Length; i++)
                {
                    listBox1.Items.Add(arr.Array[i]);
                }
            }
            else
            {
                MessageBox.Show("Выберите массив");
            }
        }
    }
}
