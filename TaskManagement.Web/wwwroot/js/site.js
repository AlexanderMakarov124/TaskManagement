/**
 * Function to load issues list.
 */
$(function () {
    loadAllIssues();
});

/**
 * Loads all issues.
 */
function loadAllIssues() {
    $.ajax({
        url: 'List',
        type: 'GET',
        success: function () {
            $('#issuesList').load(this.url);
        }
    });
}

/**
 * Loads issue info.
 * @param {number} id Issue id.
 */
function loadIssueInfo(id) {
    $.ajax({
        url: `/Issues/${id}`,
        type: 'GET',
        success: function () {
            $('#issue').load(this.url);
        },
        error: function () {
            alert('Error while loading data');
        }
    });
}

/**
 * Loads issue edit partial.
 * @param {number} id Issue id.
 */
function loadIssueEdit(id) {
    $.ajax({
        url: `/Issue/Edit/${id}`,
        type: 'GET',
        success: function () {
            $('#issue').load(this.url);
        },
        error: function () {
            alert('Error while loading data');
        }
    });
}

/**
 * Updates issue.
 * @param {number} id Issue id.
 */
function updateIssue(id) {
    const formData = $('#editForm').serialize();

    $.ajax({
        url: '/Edit',
        data: formData,
        type: 'PUT',
        success: function () {
            loadAllIssues();
            loadIssueInfo(id);
            console.log('Success request');
        },
        error: function () {
            alert('Error while loading data');
        }
    });
}
