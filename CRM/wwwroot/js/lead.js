const RenderLeadCalls = (calls, container) => {
    container.empty();

    for (const call of calls) {
        container.append(
            `<div class="card border-secondary mb-3" style="max-width: 18rem;">
                <div class="card-header">${call.lastCallWas}</div>
                <div class="card-body">
                    <h5 class="card-title">${call.employeeMail}</h5>
                </div>
            </div>`)
    }
}

const LoadLeadCalls = () => {
    const container = $("#calls")
    const leadEncodedName = container.data("encodedName");

    $.ajax({
        url: `/Lead/${leadEncodedName}/LeadCall`,
        type: 'get',
        success: function (data) {
            console.log(data);
            if (!data.length) {
                container.html("<span style='padding-left: 15px;'>No information about the last contact attempt</span>")
            } else {
                data.sort((a, b) => new Date(b.lastCallWas) - new Date(a.lastCallWas));
                RenderLeadCalls(data, container)
            }
        },
        error: function () {
            toastr["error"]("Something went wrong")
        }
    })
}