import axios from 'axios'

export interface VehicleRequest {
    price: number
    type: 'Common' | 'Luxury'
}

export interface VehicleResponse {
    basicFee: number
    specialFee: number
    associationFee: number
    storageFee: number
    total: number
}

const API = axios.create({
    baseURL: 'http://localhost:5000/api', // Ajusta según el backend real
})

export const calculateBid = async (data: VehicleRequest): Promise<VehicleResponse> => {
    const response = await API.post('/calculate', data)
    return response.data
}
