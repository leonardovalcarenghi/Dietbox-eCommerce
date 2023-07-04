export default function NavBar(props) {

    const { isCompany } = props;
    const { confirm } = window;

    /**
     * Fazer logout do usuário.
     */
    function Logout() {
        const confirmLogout = confirm("SAIR DO SISTEMA\nTem certeza que deseja sair?");
        if (confirmLogout) {
            delete localStorage["authorization"];
            window.location.href = "/";
        }
    }


    return (
        <>
            <nav className="navbar navbar-expand-lg bg-primary navbar-dark">
                <div className="container-fluid">
                    <a className="navbar-brand" href="/">
                        Dietbox e-Commerce
                    </a>
                    <button
                        className="navbar-toggler"
                        type="button"
                        data-bs-toggle="collapse"
                        data-bs-target="#navbarSupportedContent"
                        aria-controls="navbarSupportedContent"
                        aria-expanded="false"
                        aria-label="Toggle navigation"
                    >
                        <span className="navbar-toggler-icon" />
                    </button>
                    <div className="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul className="navbar-nav me-auto mb-2 mb-lg-0">

                            {/* Exibir somente se login for de empresa. */}
                            {
                                isCompany &&
                                <>
                                    <li class="nav-item dropdown">
                                        <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                            Gerenciar Produtos
                                        </a>
                                        <ul class="dropdown-menu">
                                            <li><a class="dropdown-item px-5" href="/produtos/cadastro">Cadastrar Produto</a></li>
                                        </ul>
                                    </li>
                                </>
                            }

                        </ul>
                        <form className="d-flex">
                            <button className="btn btn-outline-light px-3 me-2" type="button" onClick={Logout}>
                                <i class="bi bi-door-closed-fill me-2"></i>
                                Sair
                            </button>
                        </form>
                    </div>
                </div>
            </nav>

        </>
    )
}