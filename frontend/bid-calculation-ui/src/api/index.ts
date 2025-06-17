import axios from 'axios'

const api = axios.create({
    baseURL: import.meta.env.VITE_API_BASE_URL,
    timeout: 5000,
})

// Opcional: interceptores solo para log o manejo genérico
api.interceptors.response.use(
    res => res,
    err => {
        console.error('API Error:', err)
        return Promise.reject(err)
    }
)

export default api