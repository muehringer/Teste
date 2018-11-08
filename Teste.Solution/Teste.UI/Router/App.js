const LeitorRSSComponent = { template: '<LeitorRSSComponent></LeitorRSSComponent>' }

const routes = [
    { path: '/leitorrss', component: LeitorRSSComponent },
    { path: '*', redirect: '/leitorrss' }
]

const router = new VueRouter({
    routes
})

var app = new Vue({
    router
}).$mount('#app')
