import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/log_in.vue'
import Register from '../views/register.vue'
import Consume from '../views/consume.vue'
import Feedback from '../views/feedback.vue'
import HomeCard from '../views/HomeCard.vue'
import Footer from '../views/Footer.vue'

import AdmissionT from '@/views/admissionTicket.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    components: {
      default: Home,
      content: HomeCard,
      footer:Footer
    }
  },
  {
    path: '/Login',
    name: 'Login',
    component: Login
  },
  {
    path: '/Register',
    name: 'Register',
    component: Register,
  },
  {
    path: '/Consume',
    name: 'Consume',
    component: Consume,
    redirect:'/admissionT',
    children:[
      {path:'/admissionT',component:AdmissionT},
      {path:'/showT',component:() => import('@/views/showTicket.vue')},
      {path:'/vehicleT',component:() => import('@/views/vehicleTicket.vue')},
      {path:'/guideT',component:() => import('@/views/guideTicket.vue')},
    ]
  },
  {
    path: '/Feedback',
    name: 'Feedback',
    component: Feedback
  },
  {
    path: '/guideT',
    name: 'GuideT',
    component: () => import('@/views/guideTicket.vue')
  },
  {
    path: '/animal',
    name: 'Animal',
    component: () => import('@/views/AnimalScience.vue')
  },
  {
    path: '/transportation',
    name: 'Transportation',

    component: () => import('@/views/Transportation.vue')
  },
  {
    path: '/hotel',
    name: 'Hotel',

    component: () => import('@/views/HotelInfo.vue')
  },
  {
    path: '/service',
    name: 'Service',
    component: () => import('@/views/ConvenienceService.vue')

  },
  {
    path: '/venue',
    name: 'Venue',
    component: () => import('@/views/VenueInfo.vue')

  },
]

const router = new VueRouter({
  mode:'history',
  routes
})

export default router

Vue.use(VueRouter)




