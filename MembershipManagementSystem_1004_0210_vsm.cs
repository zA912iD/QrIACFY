// 代码生成时间: 2025-10-04 02:10:21
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace MembershipManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MemberManager _memberManager;

        public MainWindow()
        {
            InitializeComponent();
            _memberManager = new MemberManager();
        }

        private void AddMemberButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NameTextBox.Text;
                int age = Convert.ToInt32(AgeTextBox.Text);

                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }

                _memberManager.AddMember(new Member(name, age));
                DisplayMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void DisplayMembers()
        {
            // Clear the existing list
            MembersListBox.Items.Clear();

            // Add each member to the list box
            foreach (Member member in _memberManager.GetMembers())
            {
                MembersListBox.Items.Add(member);
            }
        }
    }

    public class Member
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Member(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }

    public class MemberManager
    {
        private readonly List<Member> _members;

        public MemberManager()
        {
            _members = new List<Member>();
        }

        public void AddMember(Member member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member), "Member cannot be null.");
            }

            _members.Add(member);
        }

        public List<Member> GetMembers()
        {
            return new List<Member>(_members);
        }
    }
}
