<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SplitTransactions.UpaySplitService.allocRequestTransactionAllocation>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AllocateTwo
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>AllocateTwo</h2>

    <table>
        <tr>
            <th>
                fid
            </th>
            <th>
                chart
            </th>
            <th>
                account
            </th>
            <th>
                subAccount
            </th>
            <th>
                project
            </th>
            <th>
                amount
            </th>
            <th>
                amountSpecified
            </th>
            <th>
                percent
            </th>
            <th>
                percentSpecified
            </th>
            <th>
                giftNotificationId
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.Encode(item.fid) %>
            </td>
            <td>
                <%= Html.Encode(item.chart) %>
            </td>
            <td>
                <%= Html.Encode(item.account) %>
            </td>
            <td>
                <%= Html.Encode(item.subAccount) %>
            </td>
            <td>
                <%= Html.Encode(item.project) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:F}", item.amount)) %>
            </td>
            <td>
                <%= Html.Encode(item.amountSpecified) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:F}", item.percent)) %>
            </td>
            <td>
                <%= Html.Encode(item.percentSpecified) %>
            </td>
            <td>
                <%= Html.Encode(item.giftNotificationId) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        Result: <%= ViewData["result"] %>
    </p>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

