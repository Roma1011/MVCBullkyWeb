document.addEventListener("DOMContentLoaded", function() {
    document.getElementById("loginButton").addEventListener("click", async function() {
        var email = document.getElementById("email").value;
        var password = document.getElementById("password").value;
        var errorMessageElement = document.getElementById("error-message");

        try {
            const response = await fetch('/Authentication/Login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ Email: email, Password: password })
            });

            if (!response.ok) {
                const contentType = response.headers.get('content-type');
                if (contentType && contentType.indexOf('application/json') !== -1) 
                {
                    const responseData = await response.json();
                    errorMessageElement.classList.remove("d-none");
                    errorMessageElement.innerText = responseData.message || 'Error occurred';
                } 
                else 
                {
                    const errorText = await response.text();
                    errorMessageElement.classList.remove("d-none");
                    errorMessageElement.innerText = errorText;
                }
            } else {
                window.location.href = '/Home/Index';
            }
        } catch (error) {
            errorMessageElement.classList.remove("d-none");
            errorMessageElement.innerText = 'An error occurred: ' + error.message;
        }
    });
});

