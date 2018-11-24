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
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="configuration"></param>
        public Adorer(IConfigurationRoot configuration) {
            _configuration = configuration;
        }

        /// <summary>
        /// GROUPSとTASKSの全件を返却する
        /// </summary>
        /// <returns>GROUPSとTASKSを結合したリスト</returns>
        public List<TaskOfGroup> GetAll() {
            using(var db = new kurumiContext()) {
                // GROUPSを取得する
                var groups = db.TaskGroup;
                // GROUPSとTASKSを結合する
                var query = groups.Join(db.Tasks, x => x.GroupId, y => y.GroupId, (g, t) => new TaskOfGroup {
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