<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="kr4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body> 
<form id="form1" runat="server">
<div style ="background-color:azure">
   
       
                <label style="padding: 15px; color: black; font-family: 'Times New Roman',sans-serif; font-size: 20px;" >Автор
                </label>
        <br/>
                <asp:TextBox ID="TextBox2" runat="server" Width="400px" Height="30px"></asp:TextBox>
        <br/>
               <label style="padding: 15px; color: black; font-family: 'Times New Roman',sans-serif; font-size: 20px;">Дата</label>
                <br>
                <asp:TextBox ID="TextBox1" TextMode='DateTimeLocal' runat="server" Width="400px" Height="30px" OnTextChanged="TextBox1_TextChanged">2020-10-11</asp:TextBox>
                <br />
                
      
                <label style="padding: 15px; color: black; font-family: 'Times New Roman',sans-serif; font-size: 20px;">Описание проблемы</label>
                <br>
       
                <asp:TextBox ID="TextBox3" runat="server" Width="400px" Height="30px" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
               
                <br />
       
                
                <div style="padding: 15px;">
                    <asp:Label ID="Label20" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="20px" Font-Names="Times New Roman" Text="Поля не заполнены" Visible="False"></asp:Label>

                </div>
                <div style="padding-top: 15px; width: 300px;">
                    <asp:Button ID="Button" runat="server" Text="Добавить" Width="300px" Height="30px"  BackColor="aliceblue" BorderStyle="Groove" BorderColor="black" OnClick="Button_Click" />
                </div>
                <div style="padding: 15px;">
                    <asp:Label ID="Label5" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="20px" Font-Names="Times New Roman" Text="Такая запись уже существует!" Visible="False"></asp:Label>
       
                </div><br>
        
          
        </div>
<div style="white-space: nowrap;">
   
 <div style="display: inline-block;">
    <asp:GridView ID="GridView1"  AutoGenerateSelectButton="True" runat="server" onselectedindexchanged="GridView1_OnSelectedIndexChanged" Font="Times New Roman" AutoGenerateColumns="False" Width="683px" Height="498px" CellPadding="4" ForeColor="#333333"  style="margin-top: 0px" OnRowCommand="GridView1_RowCommand">


            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="X" ItemStyle-Width="10">                    
                   <ItemTemplate>                       
                       <asp:CheckBox ID="CheckBox1" runat="server" data-Value='<%# Eval("id_rec") %>'  />
                   </ItemTemplate>
                    <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />

<ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
               </asp:TemplateField>    
                 
                <asp:TemplateField HeaderText="ID Заявки" ItemStyle-Width="50">
                    <ItemTemplate>
                        <asp:Label ID="id_rec" runat="server" Text='<%# Eval("id_rec") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>                    

                </asp:TemplateField>
               
                 <asp:TemplateField HeaderText="Дата" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="datetime" runat="server" Text='<%# Eval("datetime", "{0:MM/dd/yy H:mm}") %>'></asp:Label>
                    </ItemTemplate>
                     <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

                </asp:TemplateField>
               
                 <asp:TemplateField HeaderText="Автор"  ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="autor" runat="server"  Text='<%# Eval("autor") %>'></asp:Label>
                        
                    </ItemTemplate>
                     <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Описание" ItemStyle-Width="150" >
                    <ItemTemplate>
                        <asp:Label ID="description" runat="server" Text='<%# Eval("description") %>'></asp:Label>
                    </ItemTemplate>
                     <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:TemplateField>

                 
            </Columns>
                <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
          </asp:GridView>

        <div style="padding: 15px;">
        <asp:Button ID="Button1" runat="server" Text="Удалить" Width="300px"  BackColor="aliceblue" BorderStyle="Groove" BorderColor="black" OnClick="Button1_Click" />
        </div>
        </div>
 
    <div style="vertical-align: top; display: inline-block; padding-left: 20px;">
 <div style="">
     <br />
            <asp:Label ID="Label10" runat="server" Text="Дата"></asp:Label>
            <br />
           <asp:TextBox ID="TextBox4" TextMode="DateTimeLocal" Width="400px" Height="30px"  runat="server">2020-10-01 15:25</asp:TextBox>
            </div>
    <div style="">
            
                <br />
                <asp:Label ID="Label11" runat="server" Text="Автор"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox5" Width="400px" Height="30px" runat="server"></asp:TextBox>
            </div>
           <div style="">

                <br />
                <asp:Label ID="Label13" runat="server" Text="Описание"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox6" Width="400px" Height="30px" runat="server"></asp:TextBox>
            </div>
     <div style="padding: 15px;">
     <asp:Button ID="Button2" Width="300px"  BackColor="aliceblue" BorderStyle="Groove" BorderColor="black" runat="server" Text="Обновить" OnClick="Button2_Click" />
         <br />
                    <asp:Label ID="Label21" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="20px" Font-Names="Times New Roman" Text="Поля не заполнены" Visible="False"></asp:Label>
       
       </div>

 </div>
        
        
        

</div>
   </form>
</body>
</html>
