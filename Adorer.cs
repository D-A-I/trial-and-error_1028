using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using trial_and_error_1028.kurumi;

namespace trial_and_error_1028 {
    public interface IAdorer {
        List<TaskOfGroup> GetAll();
    }

    // Viewと同様のクラスを作る
    public class TaskOfGroup {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int TaskId { get; set; }
        public int Status { get; set; }
        public string Content { get; set; }
        public string Pic { get; set; }
        public int? Period { get; set; }
    }

    /// <summary>
    /// kurumi-ap用のテーブルにCRUDする
    /// </summary>
    public class Adorer : IAdorer {
        IConfigurationRoot _configuration;
        kurumiContext _kurumiContext;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="configuration"></param>
        public Adorer(IConfigurationRoot configuration, kurumiContext kurumiContext) {
            _configuration = configuration; // 念のため受け取っているが､､現状は不要
            _kurumiContext = kurumiContext;
        }

        /// <summary>
        /// GROUPSとTASKSの全件を返却する
        /// </summary>
        /// <remarks>
        /// Taskを返すなら、右記を戻り値にする -> async Task<List<TaskOfGroup>>
        /// </remarks>
        /// <returns>GROUPSとTASKSを結合したリスト</returns>
        public List<TaskOfGroup> GetAll() {
            // ## DEBUG
            Console.WriteLine($"DEBUG：{_configuration.GetConnectionString("kurumi")}");
            using(var db = _kurumiContext) {
                // GROUPSを取得する
                var groups = db.TaskGroup;
                // GROUPSとTASKSを結合する
                var query = groups.Join(db.Tasks, x => x.GroupId, y => y.GroupId, (g, t) =>
                    new TaskOfGroup {
                        GroupId = g.GroupId,
                            GroupName = g.Name,
                            TaskId = t.TaskId,
                            Status = t.Status,
                            Content = t.Content,
                            Pic = t.Pic,
                            Period = t.Period
                    });
                // 結果を返却する
                return query.OrderBy(x => x.GroupId).ThenBy(x => x.TaskId).ToList();
            }
        }
    }
}