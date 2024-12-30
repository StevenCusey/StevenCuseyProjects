// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('#login-form').on('submit', null, function (event) {
	event.preventDefault();
	const username = $('#username-input').val();
	const password = $('#password-input').val();
	login(username, password);
});

function retrylogin() {
	$('#saves-list-container').fadeOut(500);
	$('#login-form-container').fadeIn(1500);
}

function login(username, password) {
	$.ajax({
		url: '/LoginAJAX',
		data: {
			username: username,
			password: password
		},
		dataType: 'html',
		success: function (data) {
			//$('#login-form-container').fadeOut(500);
			//$('#saves-list-container').html(data);
			//$('#saves-list-container').fadeIn(1500);
		}
	});
}