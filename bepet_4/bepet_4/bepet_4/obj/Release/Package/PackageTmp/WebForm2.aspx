<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="bepet_4.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="position: absolute; left: 400px; margin: 20px; background-color: aliceblue; padding: 10px;">
    <form style="">
    <label style="padding: 15px; color: black; font-family: 'Times New Roman',sans-serif; font-size: 30px;" >Экспонат
        </label>
        <br>
        <asp:DropDownList ID="DropDownList1" runat="server" Width="400px" Height="30px">
    </asp:DropDownList>
        <br />
      
        <label style="padding: 15px; color: black; font-family: 'Times New Roman',sans-serif; font-size: 30px;">Зал</label>
        <br>
        <asp:DropDownList ID="DropDownList2" runat="server" Width="400px" Height="30px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
    </asp:DropDownList>
        <br />
       
        <label style="padding: 15px; color: black; font-family: 'Times New Roman',sans-serif; font-size: 30px;">Дата</label>
        <br>
        <asp:TextBox ID="TextBox1" TextMode="Date" runat="server" Width="400px" Height="30px">2020-10-11</asp:TextBox>
        <br />
        <div style="padding: 15px;">
        <asp:Label ID="Label20" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="20px" Font-Names="Times New Roman" Text="Дата не заполнена" Visible="False"></asp:Label>

        </div>
        <div style="padding-top: 15px; width: 300px;">
            <asp:Button ID="Button" runat="server" Text="Добавить" Width="300px" Height="30px"  BackColor="aliceblue" BorderStyle="Groove" BorderColor="black" OnClick="Button_Click"/>
        </div>
        <div style="padding: 15px;">
        <asp:Label ID="Label5" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="20px" Font-Names="Times New Roman" Text="Такая запись уже существует!" Visible="False"></asp:Label>
       
        </div><br>
        
    </form>

  </div>
</asp:Content>
