import { useEffect, useState } from "react";
import Product from "../Components/Product";

export default function WelcomePage() {






    return (
        <>

            <div className="d-flex align-items-center" style={{ height: "90vh" }}>

                <div style={{ width: "100%" }}>
                    <h1 className="display-4">
                        Dietbox <strong>e-Commerce</strong>
                    </h1>
                    <p className="lead">by Leonardo Valcarenghi</p>
                    <hr className="my-4" />
                    <p>O que você gostaria de fazer?</p>
                    <p className="lead">
                        <a className="btn btn-primary btn-lg px-3 me-3" href="/login">
                            <i className="bi bi-box-arrow-in-right me-2" />
                            Fazer Login
                        </a>
                        <a className="btn btn-secondary btn-lg px-3" type="button" href="/criar-conta">
                            <i className="bi bi-person-fill-add me-2" />
                            Criar Conta
                        </a>
                    </p>

                </div>

            </div>


        </>
    );
}