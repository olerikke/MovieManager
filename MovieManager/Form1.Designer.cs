using System;
using System.IO;
using System.Windows.Forms;

namespace MovieManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listMovies = new System.Windows.Forms.ListBox();
            this.ListAll = new System.Windows.Forms.Button();
            this.NewMovie = new System.Windows.Forms.TextBox();
            this.AddMovie = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listMovies
            // 
            this.listMovies.BackColor = System.Drawing.Color.YellowGreen;
            this.listMovies.FormattingEnabled = true;
            this.listMovies.ItemHeight = 16;
            this.listMovies.Location = new System.Drawing.Point(55, 179);
            this.listMovies.Name = "listMovies";
            this.listMovies.Size = new System.Drawing.Size(692, 436);
            this.listMovies.TabIndex = 0;
            // 
            // ListAll
            // 
            this.ListAll.BackColor = System.Drawing.Color.YellowGreen;
            this.ListAll.Location = new System.Drawing.Point(55, 12);
            this.ListAll.Name = "ListAll";
            this.ListAll.Size = new System.Drawing.Size(110, 41);
            this.ListAll.TabIndex = 1;
            this.ListAll.Text = "ListAll";
            this.ListAll.UseMnemonic = false;
            this.ListAll.UseVisualStyleBackColor = false;
            this.ListAll.Click += new System.EventHandler(this.GetListOfMovies_Click_1);
            // 
            // NewMovie
            // 
            this.NewMovie.BackColor = System.Drawing.Color.YellowGreen;
            this.NewMovie.Location = new System.Drawing.Point(55, 120);
            this.NewMovie.Multiline = true;
            this.NewMovie.Name = "NewMovie";
            this.NewMovie.Size = new System.Drawing.Size(692, 39);
            this.NewMovie.TabIndex = 2;
            // 
            // AddMovie
            // 
            this.AddMovie.BackColor = System.Drawing.Color.YellowGreen;
            this.AddMovie.Location = new System.Drawing.Point(55, 71);
            this.AddMovie.Name = "AddMovie";
            this.AddMovie.Size = new System.Drawing.Size(152, 43);
            this.AddMovie.TabIndex = 3;
            this.AddMovie.Text = "Add Movie";
            this.AddMovie.UseVisualStyleBackColor = false;
            this.AddMovie.Click += new System.EventHandler(this.AddMovie_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(1302, 663);
            this.Controls.Add(this.AddMovie);
            this.Controls.Add(this.NewMovie);
            this.Controls.Add(this.ListAll);
            this.Controls.Add(this.listMovies);
            this.Name = "Form1";
            this.Text = "Movies";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void Form1_Shown(object sender, System.EventArgs e)
        {

            ListAll.PerformClick();
        }

        private void GetListOfMovies_Click_1(object sender, System.EventArgs e)
        {

            listMovies.Items.Clear();
            

            var projectRepository = new ProjectRepository();
            ListBox listbox1 = projectRepository.ReadFileToListBox("Movies");

            object[] objCollection = new object[listbox1.Items.Count];
            listbox1.Items.CopyTo(objCollection, 0);

            listMovies.Items.AddRange(objCollection);




        }

        private void DeleteTask_Click_1(object sender, EventArgs e)
        {
            listMovies.Items.Remove(NewMovie.Text);

           



            var projectRepository = new ProjectRepository();
            projectRepository.ChangeTaskList(listMovies, "Movies");

            NewMovie.Text = string.Empty;
        }

        private void AddMovie_Click_1(object sender, EventArgs e)
        {

            listMovies.Items.Add(NewMovie.Text);



            var projectRepository = new ProjectRepository();
            projectRepository.ChangeTaskList(listMovies, "Movies");

            NewMovie.Text = string.Empty;


        }



        private System.Windows.Forms.ListBox listMovies;
        private System.Windows.Forms.Button ListAll;
        private TextBox NewMovie;
        private Button AddMovie;
    }
}





