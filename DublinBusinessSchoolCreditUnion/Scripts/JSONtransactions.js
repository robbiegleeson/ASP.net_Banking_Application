$(document).ready(function () {
    var url = "http://localhost:51158/TransactionJSON.svc/GetTransactions";
    $.ajax({
        url: url,
        type: "GET",
        success: function (data) {
            var returnData = data;
            console.log("Ajax Call success.");
            console.log(returnData);

            var numOfTransactions = returnData.length;
            console.log(numOfTransactions);
            var htmlTable = [];
            htmlTable.push("<table class='table'>");
            htmlTable.push("<tr><th>Account Number</th><th>Destination Account</th>");
            htmlTable.push("<th>Amount</th><th>Date &amp; Time</th>");
            htmlTable.push("<th>Description</th><th>Type</th>");
            htmlTable.push("</tr>");

            for (i = 0; i < numOfTransactions; i++) {
                console.log("Success: " + returnData[i].DestinationAccountNumber);
                htmlTable.push("<tr>");

                var date = new Date(parseInt(returnData[i].TransactionDateTime.substr(6)))
                var formatted = date.getFullYear() + "-" +
                      ("0" + (date.getMonth() + 1)).slice(-2) + "-" +
                      ("0" + date.getDate()).slice(-2) + " " + date.getHours() + ":" +
                      date.getMinutes();

                var amount = returnData[i].TransactionAmount / 100;

                htmlTable.push("<td>" + returnData[i].TransactionAccountNumber + "</td>");
                htmlTable.push("<td>" + returnData[i].DestinationAccountNumber + "</td>");
                htmlTable.push("<td> &euro;" + amount + "</td>");
                htmlTable.push("<td>" + formatted + "</td>");
                htmlTable.push("<td>" + returnData[i].TransactionDescription + "</td>");
                htmlTable.push("<td>" + returnData[i].TransactionType + "</td>");
                htmlTable.push("</tr>");
            }
            htmlTable.push("</table>");
            $("#test").append(htmlTable.join(" "));
            
        },
        error: function (xhr) {
            console.log("Call failed.");
            console.log(xhr);
        }
    });
});
    
