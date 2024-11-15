<template>
  <nav class="navbar navbar-expand-md bg-light sticky-top border-bottom">
    <div class="container">
      <a
        class="navbar-brand d-md-none"
        href="/"
      >
        <img class="logo" src="@/assets/logo.jpg" alt="logo" width="40" />
      </a>
      <button
        class="navbar-toggler"
        type="button"
        data-bs-toggle="offcanvas"
        data-bs-target="#offcanvas"
        aria-controls="offcanvas"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon"></span>
      </button>
      <div
        class="offcanvas offcanvas-end"
        tabindex="-1"
        id="offcanvas"
        aria-labelledby="offcanvasLabel"
      >
        <div class="offcanvas-body">
          <ul class="navbar-nav flex-grow-1 justify-content-between">
            <li class="nav-item">
              <img class="logo" src="@/assets/logo.jpg" alt="logo" width="40" />
            </li>
            <li class="nav-item">
              <a
                class="nav-link"
                href="https://getbootstrap.com/docs/5.3/examples/product/#"
                >Bem vindos</a
              >
            </li>
            <li class="nav-item">
              <a
                class="nav-link"
                href="https://getbootstrap.com/docs/5.3/examples/product/#"
                >Regras</a
              >
            </li>
            <li class="nav-item">
              <a
                class="nav-link"
                href="https://getbootstrap.com/docs/5.3/examples/product/#"
                >Estatísticas</a
              >
            </li>
            <li class="nav-item">
              <a
                class="nav-link"
                href="https://getbootstrap.com/docs/5.3/examples/product/#"
                >Membros</a
              >
            </li>
            <li class="nav-item">
              <a
                class="nav-link"
                href="https://getbootstrap.com/docs/5.3/examples/product/#"
                >Jogos</a
              >
            </li>
            <li class="nav-item">
              <a
                class="nav-link"
                href="https://getbootstrap.com/docs/5.3/examples/product/#"
                >Quem somos</a
              >
            </li>
            <li class="nav-item">
              <a class="nav-link" href="/sign-in">
                <i class="bi bi-lock-fill"></i>Login
              </a>
            </li>
          </ul>
        </div>
      </div>
    </div>
  </nav>
  <main>
    <div
      class="position-relative banner overflow-hidden p-3 p-md-5 m-md-3 text-center bg-body-tertiary"
    >
      <div class="col-md-6 p-lg-5 mx-auto my-5 banner-info">
        <h1 class="display-3 fw-bold banner-title">Stackovergol</h1>
        <h3 class="fw-normal text-muted mb-3">
          Diversão, amizade e competição leal
        </h3>
        <div class="d-flex gap-3 justify-content-center lead fw-normal">
          <a
            class="icon-link"
            href="https://getbootstrap.com/docs/5.3/examples/product/#"
          >
            Próxima partida
            <svg class="bi"><use xlink:href="#chevron-right"></use></svg>
          </a>
          <a
            class="icon-link"
            href="https://getbootstrap.com/docs/5.3/examples/product/#"
          >
            Seja membro
            <svg class="bi"><use xlink:href="#chevron-right"></use></svg>
          </a>
        </div>
      </div>
      <div class="product-device shadow-sm d-none d-md-block"></div>
      <div
        class="product-device product-device-2 shadow-sm d-none d-md-block"
      ></div>
    </div>
    <RouterView />
    <footer class="container py-5">
  <div class="row">
    <div class="col-12 col-md">
      <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" class="d-block mb-2" role="img" viewBox="0 0 24 24"><title>Product</title><circle cx="12" cy="12" r="10"></circle><path d="M14.31 8l5.74 9.94M9.69 8h11.48M7.38 12l5.74-9.94M9.69 16L3.95 6.06M14.31 16H2.83m13.79-4l-5.74 9.94"></path></svg>
      <small class="d-block mb-3 text-body-secondary">© 2017–2024</small>
    </div>
    <div class="col-6 col-md">
      <h5>Features</h5>
      <ul class="list-unstyled text-small">
        <li><a class="link-secondary text-decoration-none" href="https://getbootstrap.com/docs/5.3/examples/product/#">Cool stuff</a></li>
        <li><a class="link-secondary text-decoration-none" href="https://getbootstrap.com/docs/5.3/examples/product/#">Random feature</a></li>
        <li><a class="link-secondary text-decoration-none" href="https://getbootstrap.com/docs/5.3/examples/product/#">Team feature</a></li>
        <li><a class="link-secondary text-decoration-none" href="https://getbootstrap.com/docs/5.3/examples/product/#">Stuff for developers</a></li>
        <li><a class="link-secondary text-decoration-none" href="https://getbootstrap.com/docs/5.3/examples/product/#">Another one</a></li>
        <li><a class="link-secondary text-decoration-none" href="https://getbootstrap.com/docs/5.3/examples/product/#">Last time</a></li>
      </ul>
    </div>
    <div class="col-6 col-md">
      <h5>Resources</h5>
      <ul class="list-unstyled text-small">
        <li><a class="link-secondary text-decoration-none" href="https://getbootstrap.com/docs/5.3/examples/product/#">Resource name</a></li>
        <li><a class="link-secondary text-decoration-none" href="https://getbootstrap.com/docs/5.3/examples/product/#">Resource</a></li>
        <li><a class="link-secondary text-decoration-none" href="https://getbootstrap.com/docs/5.3/examples/product/#">Another resource</a></li>
        <li><a class="link-secondary text-decoration-none" href="https://getbootstrap.com/docs/5.3/examples/product/#">Final resource</a></li>
      </ul>
    </div>
    <div class="col-6 col-md">
      <h5>Resources</h5>
      <ul class="list-unstyled text-small">
        <li><a class="link-secondary text-decoration-none" href="https://getbootstrap.com/docs/5.3/examples/product/#">Business</a></li>
        <li><a class="link-secondary text-decoration-none" href="https://getbootstrap.com/docs/5.3/examples/product/#">Education</a></li>
        <li><a class="link-secondary text-decoration-none" href="https://getbootstrap.com/docs/5.3/examples/product/#">Government</a></li>
        <li><a class="link-secondary text-decoration-none" href="https://getbootstrap.com/docs/5.3/examples/product/#">Gaming</a></li>
      </ul>
    </div>
    <div class="col-6 col-md">
      <h5>About</h5>
      <ul class="list-unstyled text-small">
        <li><a class="link-secondary text-decoration-none" href="https://getbootstrap.com/docs/5.3/examples/product/#">Team</a></li>
        <li><a class="link-secondary text-decoration-none" href="https://getbootstrap.com/docs/5.3/examples/product/#">Locations</a></li>
        <li><a class="link-secondary text-decoration-none" href="https://getbootstrap.com/docs/5.3/examples/product/#">Privacy</a></li>
        <li><a class="link-secondary text-decoration-none" href="https://getbootstrap.com/docs/5.3/examples/product/#">Terms</a></li>
      </ul>
    </div>
  </div>
</footer>
  </main>

</template>

<style scoped>

.logo{
  mix-blend-mode: multiply;
}

.user-photo {
  border: 1px solid #00000000;
}

.banner{
  background-image: url('@/assets/banner.png');
  background-repeat: no-repeat;
}
.banner-info{
  background-color: #fff;
  opacity: .9;
  border-radius: 5px;
}
.banner-title{
  color: #E88026;
  text-shadow: 4px 4px #fff;
}

.icon-link{
  color: #E88026;
  text-decoration: none;
}

.icon-link:hover{
  color: #6d3503;
}
</style>