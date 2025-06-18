import axios from 'axios'

export type VehicleType = 0 | 1 // 0 = Common, 1 = Luxury

export interface VehicleRequest {
    price: number
    vehicleType: VehicleType
}

export interface VehicleResponse {
    basicFee: number
    specialFee: number
    associationFee: number
    storageFee: number
    total: number
}

const API = axios.create({
    baseURL: 'https://localhost:7119/api/v1/Bid', // Ajusta si es necesario
})

export const calculateBid = async (data: VehicleRequest): Promise<VehicleResponse> => {
    const response = await API.post('/calculate', data)
    return response.data
}