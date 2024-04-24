function signIn(event) {
    event.preventDefault();

    const signInForm = document.getElementById('signInForm');
    const email = signInForm.elements.email.value;
    const password = signInForm.elements.password.value;

    fetch('http://localhost:5069/api/SignIn', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ email, password })
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.json();
    })
    .then(data => {
        if (data.success) {
            alert(data.message);
            // Redirect or perform other actions upon successful sign-in
        } else {
            alert(data.message);
        }
    })
    .catch(error => {
        console.error('Error:', error);
        alert('An error occurred. Please try again later.');
    });
}

function onsigninPageLoad() {
    const signInForm = document.getElementById('signInForm');
    signInForm.addEventListener('submit', signIn);
}
