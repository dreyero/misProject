function contactUs(){
    var params = {
        name: document.getElementById("name").value,
        email: document.getElementById("email").value,
        message: document.getElementById("message").value,
    };
    const serviceID = "service_vq6pa68";
    const templateID = "template_saz9cki";
    
    emailjs
    .send(serviceID, templateID, params)
    .then((res) => {
        alert("Your email was sent!");
    })
    .catch((err) => console.log(err)); 
}

