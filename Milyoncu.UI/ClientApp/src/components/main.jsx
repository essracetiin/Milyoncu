import React from "react";
import {useRef} from "react";

const Home = () => {
  const ref = useRef(null);
  const handleClick = () => {
    ref.current?.scrollIntoView({behavior:'smooth'})
  }
  return (
    <>
      <div className="hero border-1 pb-3">
        <div onClick={handleClick} className="card bg-dark text-white border-0 mx-3">
          <img
            className="card-img img-fluid"
            src="https://www.dinlazyazilim.com/eticaret.jpg"
            alt="Card"
            height={500}
          />
          <div className="card-img-overlay d-flex align-items-end">
            <div className="container">
              <h5 className="card-title fs-1 text fw-lighter">Milyoncu</h5>
              <p className="card-text fs-5 d-none d-sm-block ">
                Kazanmak için sen de bilet satın al !
              </p>
            </div>
          </div>
        </div>
        <div ref={ref}></div>

      </div>
    </>
  );
};

export default Home;
