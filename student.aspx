<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master"
AutoEventWireup="true" CodeBehind="student.aspx.cs"
Inherits="DatabaseActivity.student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<style>
    .student-container {
        max-width: 1100px;
        margin: auto;
    }

    h2 {
        color: #2c3e50;
        margin-bottom: 25px;
        border-bottom: 3px solid #3498db;
        padding-bottom: 10px;
    }

    .form-table {
        width: 100%;
    }

    .form-table td {
        padding: 10px;
    }

    .form-table label {
        font-weight: bold;
        color: #2c3e50;
    }

    .input-box {
        width: 100%;
        padding: 10px;
        border: 1px solid #dcdcdc;
        border-radius: 5px;
        font-size: 14px;
    }

    .input-box:focus {
        border-color: #3498db;
        outline: none;
    }

    .button-panel {
        margin-top: 15px;
        margin-bottom: 20px;
    }

    .btn {
        border: none;
        padding: 10px 18px;
        color: white;
        font-weight: bold;
        border-radius: 5px;
        cursor: pointer;
        margin-right: 5px;
    }

    .insert {
        background: #27ae60;
    }

    .search {
        background: #2980b9;
    }

    .update {
        background: #f39c12;
    }

    .delete {
        background: #c0392b;
    }

    .btn:hover {
        opacity: 0.9;
    }

    #ContentPlaceHolder1_lblMessage {
        display: block;
        padding: 12px;
        margin-top: 10px;
        margin-bottom: 20px;
        background: #ecf5ff;
        border-left: 5px solid #3498db;
        font-weight: bold;
    }

    .grid {
        width: 100%;
        border-collapse: collapse;
        margin-top: 20px;
        background: white;
    }

    .grid th {
        background: #2c3e50;
        color: white;
        padding: 12px;
        text-align: left;
    }

    .grid td {
        padding: 10px;
        border-bottom: 1px solid #ddd;
    }

    .grid tr:nth-child(even) {
        background: #f8f9fa;
    }

    .grid tr:hover {
        background: #e8f4fc;
    }

    h3 {
        color: #2c3e50;
        margin-top: 30px;
    }
</style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h2>Student Registration</h2>

Student ID
<asp:TextBox ID="txtID" runat="server" CssClass="input-box" />

First Name
<asp:TextBox ID="txtFirst" runat="server" CssClass="input-box" />

Last Name
<asp:TextBox ID="txtLast" runat="server" CssClass="input-box" />

Gender
<asp:DropDownList ID="ddlGender" runat="server" CssClass="input-box">
    <asp:ListItem>Male</asp:ListItem>
    <asp:ListItem>Female</asp:ListItem>
</asp:DropDownList>

Department
<asp:TextBox ID="txtDepartment" runat="server" CssClass="input-box" />

Telephone
<asp:TextBox ID="txtTelephone" runat="server" CssClass="input-box" />

<br /><br />

<asp:Button ID="btnInsert" runat="server" Text="Insert" CssClass="btn insert" OnClick="btnInsert_Click" />
<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn search" OnClick="btnSearch_Click" />
<asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn update" OnClick="btnUpdate_Click" />
<asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn delete" OnClick="btnDelete_Click" />

<br /><br />

<asp:Label ID="lblMessage" runat="server" />

<h3>Students List</h3>

<asp:GridView ID="gvStudents" runat="server"
AutoGenerateColumns="True"
CssClass="grid"
Width="100%" />

</asp:Content>