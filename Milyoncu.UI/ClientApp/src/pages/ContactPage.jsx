import React from "react";
import { Footer, Navbar } from "../components";
const ContactPage = () => {
  return (
    <>
      <Navbar />
      <div className="container my-3 py-3">
        <h1 className="text-center">İletişim</h1>
        <hr />
        <div class="row my-4 h-100">
          <div className="col-md-4 col-lg-4 col-sm-8 mx-auto">
            <form>
              <div class="form my-3">
                <label for="Name">Ad / Soyad</label>
                <input
                  type="email"
                  class="form-control"
                  id="Name"
                  placeholder="Ad ve Soyad giriniz"
                />
              </div>
              <div class="form my-3">
                <label for="Email">Email</label>
                <input
                  type="email"
                  class="form-control"
                  id="Email"
                  placeholder="Mail adresinizi giriniz"
                />
              </div>
              <div class="form  my-3">
                <label for="Password">Mesaj</label>
                <textarea
                  rows={5}
                  class="form-control"
                  id="Password"
                  placeholder="Mesajınızı giriniz"
                />
              </div>
              <div className="text-center">
                <button
                  class="my-2 px-4 mx-auto btn btn-dark"
                  type="submit"
                  disabled
                >
                  Gönder
                </button>
              </div>
            </form>
          </div>
        </div>
      </div>
      <Footer />
    </>
  );
};

export default ContactPage;
