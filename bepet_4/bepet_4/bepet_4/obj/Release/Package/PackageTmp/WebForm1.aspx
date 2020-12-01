<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="bepet_4.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="position: absolute; left: 400px; margin: 20px;" >
        <label style="padding: 15px; color: black; font-family: 'Times New Roman',sans-serif; font-size: 20px;">Начальная дата:</label>
        <asp:TextBox ID="TextBox1" TextMode="Date" runat="server" Width="300px" Height="30px">2020-10-11</asp:TextBox>
        <br />
        <label style="padding: 15px; color: black; font-family: 'Times New Roman',sans-serif; font-size: 20px;">Конечная дата:</label>
        <asp:TextBox ID="TextBox2" TextMode="Date" runat="server" Width="300px" Height="30px">2020-11-11</asp:TextBox>
        <br>
        <div style="padding: 15px;">
        <asp:Button ID="Button2" runat="server"  Width="300px" Text="Найти"  BackColor="aliceblue" BorderStyle="Groove" BorderColor="black" OnClick="Button2_Click" />
     </div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="700px" Height="500px" CellPadding="4" ForeColor="#333333" GridLines="None">


            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="X" ItemStyle-Width="10">                    
                   <ItemTemplate>                       
                       <asp:CheckBox ID="CheckBox1" runat="server" data-Value='<%# Eval("id_tr") %>'  />
                   </ItemTemplate>
                    <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />

<ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
               </asp:TemplateField>               
                <asp:TemplateField HeaderText="ID перемещения" ItemStyle-Width="50">
                    <ItemTemplate>
                        <asp:Label ID="id_tr" runat="server" Text='<%# Eval("id_tr") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>                    

                </asp:TemplateField>
                <asp:TemplateField HeaderText="id экспоната" Visible="false" ItemStyle-Width="50">
                    <ItemTemplate>
                        <%--<asp:Label ID="id_exp" runat="server" Text='<%# Eval("id_exp_fk") %>'></asp:Label>--%>
                    </ItemTemplate>
                    <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Экспонат" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="name_exp" runat="server" Text='<%# Eval("name_exp") %>'></asp:Label>
                    </ItemTemplate>
                     <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="id зала" Visible="false" ItemStyle-Width="50">
                    <ItemTemplate>
                        <asp:Label ID="id_h" runat="server" Text='<%# Eval("id_h_fk") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Зал" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="name_h" runat="server" Text='<%# Eval("name_h") %>'></asp:Label>
                    </ItemTemplate>
                     <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Дата перемещения" ItemStyle-Width="150" >
                    <ItemTemplate>
                        <asp:Label ID="date" runat="server" Text='<%# Eval("date","{0:dd.MM.yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                     <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Дней в зале" ItemStyle-Width="50">
                    <ItemTemplate>
                        <asp:Label ID="stay" runat="server" Text='<%# Eval("stay") %>'></asp:Label>
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
              <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
              <SortedAscendingCellStyle BackColor="#E9E7E2" />
              <SortedAscendingHeaderStyle BackColor="#506C8C" />
              <SortedDescendingCellStyle BackColor="#FFFDF8" />
              <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
          </asp:GridView>
       
        <div style="padding: 15px;">
    <asp:Button ID="Button1" runat="server" Text="Удалить" Width="300px"  BackColor="aliceblue" BorderStyle="Groove" BorderColor="black" OnClick="Button1_Click"/>
            </div>
    </div>

</asp:Content>
