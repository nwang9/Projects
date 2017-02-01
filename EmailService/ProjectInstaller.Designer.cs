﻿namespace EmailService
{
    partial class ProjectInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MailServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.MailServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // MailServiceProcessInstaller
            // 
            this.MailServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.MailServiceProcessInstaller.Password = null;
            this.MailServiceProcessInstaller.Username = null;
            // 
            // MailServiceInstaller
            // 
            this.MailServiceInstaller.Description = "EmailService";
            this.MailServiceInstaller.DisplayName = "EmailService";
            this.MailServiceInstaller.ServiceName = "EmailService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.MailServiceProcessInstaller,
            this.MailServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller MailServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller MailServiceInstaller;
    }
}