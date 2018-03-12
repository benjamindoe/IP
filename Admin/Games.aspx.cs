using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Games : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GridView1_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow currentRow = GridView1.Rows[GridView1.EditIndex];
        FileUpload file = (FileUpload)currentRow.FindControl("fileImage");
        if (file != null && file.HasFile)
        {
            string uploadPath = "/Uploads/";
            string serverPath = Server.MapPath(uploadPath);
            HiddenField oldFile = (HiddenField)currentRow.FindControl("hdnOldImage");
            if (oldFile != null)
            {
                string oldPath = Server.MapPath(oldFile.Value);
                System.IO.File.Delete(oldPath);
            }
            try
            {
                string fileName = UploadImage(file);
                GamesSqlDataSource.UpdateParameters["image"].DefaultValue = fileName;
                GamesSqlDataSource.DataBind();
                GamesSqlDataSource.Update();
            }
            catch
            {

            }
        }
        return;
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow footerRow = GridView1.FooterRow;
        if (e.CommandName == "Insert" && Page.IsValid)
        {
            TextBox title = (TextBox)footerRow.FindControl("txtNewTitle");
            TextBox description = (TextBox)footerRow.FindControl("txtNewDescription");
            TextBox price = (TextBox)footerRow.FindControl("txtNewPrice");
            TextBox releaseDate = (TextBox)footerRow.FindControl("txtNewReleaseDate");
            TextBox ageRating = (TextBox)footerRow.FindControl("txtNewAge");
            FileUpload file = (FileUpload)footerRow.FindControl("fileNewImage");

            GamesSqlDataSource.InsertParameters["title"].DefaultValue = title.Text;
            GamesSqlDataSource.InsertParameters["description"].DefaultValue = description.Text;
            GamesSqlDataSource.InsertParameters["price"].DefaultValue = price.Text;
            GamesSqlDataSource.InsertParameters["release_date"].DefaultValue = releaseDate.Text;
            GamesSqlDataSource.InsertParameters["age_rating"].DefaultValue = ageRating.Text;

            try
            {
                if (file != null)
                {
                    string fileName = UploadImage(file);
                    GamesSqlDataSource.InsertParameters["image"].DefaultValue = fileName;
                }
                else
                {
                    GamesSqlDataSource.InsertParameters["image"].DefaultValue = "";
                }
                GamesSqlDataSource.Insert();
            }
            catch (Exception ex)
            {
                lblErrors.Text = ex.Message;
            }
        }
    }

    protected string UploadImage(FileUpload file)
    {

        if (file != null)
        {
            string pattern = @"image\/png|image\/jpe?g|image\/gif";
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            Match match = r.Match(file.PostedFile.ContentType);
            if (match.Success)
            {
                string uploadPath = "/Uploads/";
                string serverPath = Server.MapPath(uploadPath);
                string fileName = string.Format(@"{0}", DateTime.Now.Ticks);
                string extension = Path.GetExtension(file.FileName);
                fileName += fileName + extension;
                file.SaveAs(serverPath + fileName);
                return uploadPath + fileName;
            } else
            {
                throw new Exception("File must be a PNG, JPEG or GIF");
            }

        } else
        {
            throw new Exception("File cannot be null");
        }

    }
}
