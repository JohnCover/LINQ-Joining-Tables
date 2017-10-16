using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class JoiningTableData : Form
    {
        public JoiningTableData()
        {
            InitializeComponent();
        } // end constructor

        private void JoiningTableData_Load(object sender, EventArgs e)
        {
            // Entity Framework DBContext
            Lab4.BooksEntities dbcontext =
               new Lab4.BooksEntities();


            //part A
            //get a list of all titles and authors who wrote them. Sort by title
            var authorsAndTitles =
                    from book in dbcontext.Titles
                    from author in book.Authors
                    orderby book.Title1
                    select new { book.Title1, author.FirstName, author.LastName };
            //prints sort by title
            outputTextBox.AppendText("\nList of all titles and authors who wrote them by title:\n");
            outputTextBox.AppendText("\n");
            foreach (var x in authorsAndTitles)
            { outputTextBox.AppendText(x.Title1 + ":  " + x.FirstName + " " + x.LastName + "\n"); }
            outputTextBox.AppendText("\n");

            //part B
            //get a list of all the titles and the authors who wrote them. Sort the result by title. For each title sort the authors alphabetically by last name, then first name.
            var partb =
                from book in dbcontext.Titles
                from author in book.Authors
                orderby book.Title1, author.LastName, author.FirstName
                select new { book.Title1, author.FirstName, author.LastName };
            //prints sort the result by title. For each title sort the authors alphabetically by last name, then first name.
            outputTextBox.AppendText("\nAuthors and titles with authors sorted for each title: \n");
            outputTextBox.AppendText("\n");
            foreach (var x in partb)
            { outputTextBox.AppendText(x.Title1 + ":  " + x.FirstName + " " + x.LastName + "\n"); }
            outputTextBox.AppendText("\n");

            //part C
            //get a list of all the authors grouped by title, sorted by title; for a given title sort the author names alphabetically by last name first then first name.
            var partc =
                from book in dbcontext.Titles
                orderby book.Title1
                select new
                {
                    book.Title1,
                    Name = from author in book.Authors
                           orderby author.LastName, author.FirstName
                           select author.FirstName + " " + author.LastName
                };
            //prints grouped by title, sorted by title; for a given title sort the author names alphabetically by last name first then first name.
            outputTextBox.AppendText("Titles grouped by author: ");
            outputTextBox.AppendText("\n");
            foreach (var title in partc)
            {
                outputTextBox.AppendText(title.Title1 + ":\n");//prints title
                foreach (var name in title.Name)
                { outputTextBox.AppendText(name + "\n"); }
            }


        } // end method JoiningTableData_Load
    } // end class JoiningTableData
}//end Lab4
