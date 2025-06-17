import type { BidRequest, BidResponse } from '@/types'
import { postCalculateBid } from '@/api/bid'

export async function calculateBid(req: BidRequest): Promise<BidResponse> {
  const data = await postCalculateBid(req)
  return {
    basicFee: parseFloat(data.basicFee.toFixed(2)),
    specialFee: parseFloat(data.specialFee.toFixed(2)),
    associationFee: parseFloat(data.associationFee.toFixed(2)),
    storageFee: parseFloat(data.storageFee.toFixed(2)),
    total: parseFloat(data.total.toFixed(2)),
  }
}