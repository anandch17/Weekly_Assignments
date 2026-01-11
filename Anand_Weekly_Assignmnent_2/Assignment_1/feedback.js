const form = document.getElementById("form");

form.addEventListener("submit", function (e) {
    e.preventDefault();

    clearErrors();

    let ok = true;

    const name = document.getElementById("name").value.trim();
    const email = document.getElementById("email").value.trim();
    const mobile = document.getElementById("mobile").value.trim();
    const request = document.getElementById("request").value;
    const policy = document.getElementById("policy").value;
    const msg = document.getElementById("msg").value.trim();
    const rate = document.querySelector("input[name='rate']:checked");

    if (name === "") {
        showError("errName", "Name required");
        ok = false;
    }

    if (email === "") {
        showError("errEmail", "Email required");
        ok = false;
    }

    if (!/^\d{10}$/.test(mobile)) {
        showError("errMobile", "Enter 10 digit number");
        ok = false;
    }

    if (request === "") {
        showError("errRequest", "Select request type");
        ok = false;
    }

    if (policy === "") {
        showError("errPolicy", "Select policy type");
        ok = false;
    }

    if (msg.length < 10) {
        showError("errMsg", "Minimum 10 characters");
        ok = false;
    }

    if (!rate) {
        showError("errRate", "Select rating");
        ok = false;
    }

    if (ok) {
        document.getElementById("success").innerText =
            "Thank you! Your enquiry has been successfully submitted.";
        form.reset();
    }
});

function showError(id, text) {
    document.getElementById(id).innerText = text;
}

function clearErrors() {
    document.querySelectorAll("small").forEach(s => s.innerText = "");
    document.getElementById("success").innerText = "";
}
