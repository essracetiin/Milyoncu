import React from 'react'
import { Footer, Navbar } from "../components";
const AboutPage = () => {
  return (
    <>
      <Navbar />
      <div className="container my-3 py-3">
        <h1 className="text-center">Hakkımızda</h1>
        <hr />
        <p className="lead text-center">
          İstanbul Topkapı Üniversitesi İŞKUR Destekli Nitelikli Bilişim Uzmanı Yetiştirme Programı 
          - 680 saatlik Yazılım Uzmanlığı/ERP eğitimi içerisinde Asp.Net, MVC, Web API, C#, JavaScript,
          React Js, MSSQL, Html, Css, Bootstrap konularını öğrendik. Kendimizi geliştirmek adına 
          grup çalışmasıyla Milyoncu projesini geliştirdik. Hedefimiz; kullanıcı deneyimiyle e-ticaret 
          sitemizi buluşturup sorunsuz ve kullanılabilir bir platform oluşturmak. Bu yolda projelerimizi 
          hayata geçirmeye devam eden Yazılım Geliştiricileriyiz.
        </p>

        <h2 className="text-center py-4">Biz Kimiz?</h2>
        <div className="row">
          <div className="col-md-3 col-sm-6 mb-3 px-3">
            <div className="card h-100">
              <a className="text-dark" href="https://github.com/GulmezBurak" target="_blank" rel="noreferrer">
              <img className="card-img-top img-fluid" src="https://avatars.githubusercontent.com/u/111693699?v=4" alt="" height={160} />
              <div className="card-body">
                <h5 className="card-title text-center">Burak Elber GÜLMEZ</h5>
              </div></a>
            </div>
          </div>
          <div className="col-md-3 col-sm-6 mb-3 px-3">
            <div className="card h-100">
            <a className="text-dark" href="https://github.com/dogukantokk" target="_blank" rel="noreferrer">
              <img className="card-img-top img-fluid" src="https://avatars.githubusercontent.com/u/120035317?v=4" alt="" height={160} />
              <div className="card-body">
                <h5 className="card-title text-center">Doğukan TOK</h5>
              </div></a>
            </div>
          </div>
          <div className="col-md-3 col-sm-6 mb-3 px-3">
            <div className="card h-100">
            <a className="text-dark" href="https://github.com/essracetiin" target="_blank" rel="noreferrer">
              <img className="card-img-top img-fluid" src="https://avatars.githubusercontent.com/u/107802521?v=4" alt="" height={160} />
              <div className="card-body">
                <h5 className="card-title text-center">Esra ÇETİN</h5>
              </div></a>
            </div>
          </div>
          <div className="col-md-3 col-sm-6 mb-3 px-3">
            <div className="card h-100">
            <a className="text-dark" href="https://github.com/ozcancambazogluu" target="_blank" rel="noreferrer">
              <img className="card-img-top img-fluid" src="https://images.pexels.com/photos/356056/pexels-photo-356056.jpeg?auto=compress&cs=tinysrgb&w=600" alt="" height={160} />
              <div className="card-body">
                <h5 className="card-title text-center">Özcan CAMBAZOĞLU</h5>
              </div></a>
            </div>
          </div>
        </div>
      </div>
    </>
  )
}

export default AboutPage