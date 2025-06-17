import api from './index'
import type { BidRequest, BidResponse } from '@/types'

export async function postCalculateBid(data: BidRequest): Promise<BidResponse> {
    const response = await api.post<BidResponse>('/api/bid/calculate', data)
    return response.data
}