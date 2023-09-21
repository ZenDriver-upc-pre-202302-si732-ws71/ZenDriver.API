using ZenDriver.API.Message.Domain.Repositories;
using ZenDriver.API.Shared.Persistence.Repositories;
using ZenDriver.API.Shared.Persistence.Contexts;
using ZenDriver.API.Message.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ZenDriver.API.Message.Persistence.Repositories
{
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public MessageRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<MessageZenDriver>> GetMessagesAsync()
        {
            return await _context.Messages.Include(p => p.Emitter).Include(q => q.Receiver).ToListAsync();
        }

        public async Task AddMessageAsync(MessageZenDriver message)
        {
            await _context.Messages.AddAsync(message);
        }

        public async Task<MessageZenDriver> FindMessageByIdAsync(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public async Task<IEnumerable<MessageZenDriver>> GetLastMessageRecruiter(int id)
        {
            var lastMessage = await _context.Messages.FromSqlInterpolated($"SELECT * FROM messages m WHERE id IN (SELECT MAX(id) FROM messages WHERE emitter_id = {id} GROUP BY receiver_id)").Include(p => p.Receiver).ToListAsync();
            return lastMessage;
        }

        public async Task<IEnumerable<MessageZenDriver>> GetLastMessageDriver(int id)
        {
            var lastMessage = await _context.Messages.FromSqlInterpolated($"SELECT * FROM messages m WHERE id IN (SELECT MAX(id) FROM messages WHERE receiver_id = {id} GROUP BY emitter_id)").Include(p => p.Emitter).ToListAsync();
            return lastMessage;
        }

        public async Task<IEnumerable<MessageZenDriver>?> GetMessagesByEmitterIdAsync(int emitterId)
        {
            var messages = await _context.Messages.Where(p => p.EmitterId == emitterId)
                .Include(x=>x.Emitter)
                .Include(x=>x.Receiver).ToListAsync();
            return messages;
        }

        public async Task<IEnumerable<MessageZenDriver>?> GetMessagesByEmitterIdReceiverIdAsync(int emitterId, int receiverId)
        {
            var messages = await _context.Messages
                .Where(p => (p.EmitterId == emitterId && p.ReceiverId == receiverId) || (p.EmitterId == receiverId && p.ReceiverId == emitterId))
                .Include(x=>x.Emitter)
                .Include(x=>x.Receiver)
                .OrderBy(x=>x.CreatedAt).ToListAsync();
            return messages;
        }

        public List<MessageZenDriver> GetLatestMessagesByReceiverIdAsync(int receiverId)
        {
            var latestMessages = _context.Messages
                .Include(m => m.Emitter)
                .Include(m => m.Receiver)
                .Where(m => m.ReceiverId == receiverId || m.EmitterId == receiverId)
                .AsEnumerable()
                .GroupBy(m => m.ReceiverId == receiverId ? m.EmitterId : m.ReceiverId)
                .Select(g => g.OrderByDescending(m => m.CreatedAt).FirstOrDefault())
                .ToList();

            return latestMessages;
        }



    }
}