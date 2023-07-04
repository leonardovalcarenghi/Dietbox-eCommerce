import { useState } from "react";
import { IsEmail } from "../Utils";
import { Post } from "../Request";

export default function LoginPage({ setIsAuth }) {

    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [loginAs, setLoginAs] = useState(1); // 1 = Cliente | 2 = Empresa

    const [emailMessage, setEmailMessage] = useState("");
    const [passwordMessage, setPasswordMessage] = useState("");

    /**
     * Realizar login do usuário.
     * @returns 
     */
    async function Login() {

        const validate = ValidateInputs();
        if (!validate) { return; }

        setLoading(true);
        setError(null);

        try {
            const result = await Post(loginAs == 1 ? "/customers/login" : "/companies/login");
            const { authorization } = result;
            localStorage["authorization"] = authorization;
            localStorage["loginAs"] = loginAs;
            window.location.href = "/"; // Ir para ínicio.
        }
        catch (error) {
            setLoading(false);
            setError(error);
        }
        
    }

    /**
     * Validar campos do login.
     * @returns 
     */
    function ValidateInputs() {

        if (!email) {
            document.getElementById("emailInput").focus();
            setEmailMessage("Digite o e-mail de acesso.");
            return false;
        }

        if (!IsEmail(email)) {
            document.getElementById("emailInput").focus();
            setEmailMessage("O e-mail digitado não é válido.");
            return false;
        }

        if (!password) {
            document.getElementById("passwordInput").focus();
            setPasswordMessage("Digite a senha de acesso.");
            return false;
        }

        return true;
    }


    return (
        <>
            <div className="container">
                <div className="row justify-content-center">
                    <div className="col-6">
                        <div className="card" >

                            <div className="card-body">
                                <h5 className="card-title display-6">Login</h5>
                                <p className="card-text">Insira suas credenciais para acessar o sistema.</p>



                                <form>

                                    <div className="mb-3">
                                        <label className="form-label" htmlFor="emailInput">
                                            <i class="bi bi-at me-1"></i>
                                            E-mail
                                        </label>
                                        <input
                                            className="form-control"
                                            id="emailInput"
                                            type="email"
                                            value={email}
                                            onChange={({ target }) => setEmail(target.value)}
                                            onKeyUp={() => setEmailMessage("")}
                                            disabled={loading}
                                        />
                                        <div className="form-text">
                                            {emailMessage}
                                        </div>
                                    </div>

                                    <div className="mb-3">
                                        <label className="form-label" htmlFor="passwordInput">
                                            <i class="bi bi-key me-1"></i>
                                            Senha
                                        </label>
                                        <input
                                            className="form-control"
                                            id="passwordInput"
                                            type="password"
                                            value={password}
                                            onChange={({ target }) => setPassword(target.value)}
                                            onKeyUp={() => setPasswordMessage("")}
                                            disabled={loading}
                                        />
                                        <div className="form-text">
                                            {passwordMessage}
                                        </div>
                                    </div>

                                    <div className="mb-3">
                                        <label className="form-label" htmlFor="emailInput">
                                            {/* <i class="bi bi-person me-2"></i> */}
                                            Entrar como
                                        </label>
                                        <div className="form-check">
                                            <input
                                                className="form-check-input"
                                                type="radio"
                                                name="loginAsRadio"
                                                id="customerRadio"
                                                checked={loginAs == 1}
                                                onChange={() => setLoginAs(1)}
                                                disabled={loading}
                                            />
                                            <label className="form-check-label" htmlFor="customerRadio">
                                                <i className="bi bi-person-fill me-1"></i>
                                                Cliente
                                            </label>
                                        </div>
                                        <div className="form-check">
                                            <input
                                                className="form-check-input"
                                                type="radio"
                                                name="loginAsRadio"
                                                id="companyRadio"
                                                checked={loginAs == 2}
                                                onChange={() => setLoginAs(2)}
                                                disabled={loading}
                                            />
                                            <label className="form-check-label" htmlFor="companyRadio">
                                                <i className="bi bi-building-fill me-1"></i>
                                                Empresa
                                            </label>
                                        </div>
                                    </div>

                                </form>

                                {
                                    error &&
                                    <>
                                        <div class="alert alert-danger" role="alert">
                                            {error ? error.message : "Ocorreu um erro ao tentar fazer login."}
                                        </div>
                                    </>
                                }

                                <button
                                    className="btn btn-primary px-5"
                                    type="button"
                                    style={{ width: "100%" }}
                                    onClick={() => Login()}
                                    disabled={loading}>

                                    {
                                        loading ?
                                            <>
                                                <span class="spinner-border spinner-border-sm me-2" role="status" aria-hidden="true"></span>
                                                Autenticando...
                                            </>
                                            :
                                            <>
                                                <i className="bi bi-box-arrow-in-right me-2" />
                                                Login
                                            </>
                                    }

                                </button>

                                <button
                                    className="btn btn-outline-secondary mt-2"
                                    type="button"
                                    style={{ width: "100%" }}
                                    onClick={() => window.location.href = "/"}
                                    disabled={loading}>
                                    <i class="bi bi-arrow-left me-2"></i>
                                    Voltar
                                </button>


                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </>
    );
}